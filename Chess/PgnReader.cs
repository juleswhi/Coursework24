using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Chess;

public record struct PGN(
    string Event,
    string Site,
    DateTime? Date,
    int Round,
    string White,
    string Black,
    string Result,
    string? Annotator,
    int? PlyCount,
    string? TimeControl,
    DateTime? Time,
    string? Termination,
    string? Mode,
    FEN? FEN,
    List<(SAN, SAN)> Moves
    )
{

    public static PGN From(List<(SAN, SAN)> Moves)
    {
        return new PGN(Moves);
    }
    public static PGN From(List<(Notation, Notation)> Moves)
    {
        return new PGN(Moves);
    }

    public PGN(List<(SAN,SAN)> Moves) : this(string.Empty, string.Empty, null, -1, string.Empty, string.Empty, string.Empty,
        null, null, null, null, null, null, null, Moves)
    {

    }

    public PGN(List<(Notation, Notation)> moves) : this(string.Empty, string.Empty, null, -1, string.Empty, string.Empty, string.Empty,
        null, null, null, null, null, null, null, new())
    {
        foreach (var move in moves)
        {
            Moves.Add(
                (
                new SAN($"{move.Item1.Item1}{move.Item1.Item2}"),
                new SAN($"{move.Item2.Item1}{move.Item2.Item2}")
                )
                );
        }
    }


}

public class PgnReader
{

    public List<PGN> Games { get; set; } = new();

    public void FromFile(string path)
    {
        FromString(File.ReadAllLines(path));
    }

    public void FromBytes(params byte[] bytes)
    {
        string str = Encoding.Default.GetString(bytes);

        string[] parts = str.Split(new string[]
        {
            "\r\n\r\n"
        },
        StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i < parts.Length; i+=2)
        {

            PGN pgn = new(string.Empty, string.Empty, default, -1, string.Empty, string.Empty,
                string.Empty, null, null, null, null, null, null, null, new());

            var meta = LexMetadata(parts[0]).Where(x => x.Type == TokenType.KEY 
                                                   || x.Type == TokenType.VALUE);

            var game = LexGame(parts[1]);

            var props = typeof(PGN).GetProperties();

            string currentField = "";

            foreach(var prop in props)
            {
                Token field = meta.FirstOrDefault(x => (string)x.Data! == prop.Name);
                if(field.Type == TokenType.KEY)
                {
                    currentField = (string)field.Data!;
                    Debug.Print($"KEY: {field.Data!}");
                    continue;
                }

                Debug.Print($"VALUE: {field.Data!}");

                object output = field.Data!;
                if (prop.PropertyType != typeof(string)) 
                {
                    output = Convert.ChangeType(field.Data, prop.PropertyType);
                    Debug.Print($"Converting to type {prop.PropertyType}");
                }
                prop.SetMethod?.Invoke(pgn, new object[] { field.Data! });
                Debug.Print($"{prop.GetMethod?.Invoke(pgn, new object[] { })}");

            }

        }
    }

    private PGN ToPGN(IEnumerable<Token> meta, IEnumerable<Token> game)
    {



        return default;
    }

    public void FromString(params string[] str)
    {
        foreach(var line in str)
        {
            if(line == "")
            {
                break;
            }

            Debug.Print(line);
        }
    }

    enum TokenType
    {
        KEY,
        VALUE,
        NOTATION,
        LEFT_BRACKET,
        RIGHT_BRACKET,
        LEFT_CURLY,
        RIGHT_CURLY
    }

    record struct Token(TokenType Type, object? Data)
    {
        public override string ToString() =>
            $"{Type}: {Data ?? ""}";
    }

    private IEnumerable<Token> LexMetadata(string str)
    {
        int _current = 0;

        var next = (int n) => _current += n;
        var peek = () => str[_current++];
        var current = () => str[_current];

        var consume = (TokenType type, object? data = null) =>
        {
            _current++;
            return new Token(type, data);
        };

        Type pgnType = typeof(PGN);
        var props = pgnType.GetProperties();

        for(; _current < str.Length;)
        {
            switch(current())
            {

                case '[':
                    yield return consume(TokenType.LEFT_BRACKET);
                    break;

                case ']':
                    yield return consume(TokenType.RIGHT_BRACKET);
                    break;



                case '"':
                    {

                        StringBuilder sb = new();
                        next(1);
                        while(current() != '"')
                        {
                            sb.Append(current());
                            next(1);
                        }

                        yield return consume(
                            TokenType.VALUE,
                            sb.ToString()
                            );

                        break;
                    }


                default:
                    {
                        if(!char.IsLetterOrDigit(current()))
                        {
                            next(1);
                            break;
                        }
                        StringBuilder sb = new();
                        while (char.IsLetterOrDigit(current()))
                        {
                            sb.Append(current());
                            next(1);
                        }

                        yield return consume(
                            TokenType.KEY,
                            sb.ToString()
                            );

                        continue;
                    }
            }
        }


    }

    private IEnumerable<Token> LexGame(string str)
    {
        int _current = 0;

        var next = (int n = 1) => _current += n;
        var peek = () => str[_current++];
        var current = () => str[_current];

        var consume = (TokenType type, object? data = null) =>
        {
            _current++;
            return new Token(type, data);
        };

        for (; _current < str.Length;)
        {
            // Debug.Print("CURRENT TOKEN: {0}", current());
            switch (current())
            {
                case '{':
                    {
                        while (current() != '}' && current() != ')')
                        {
                            next(1);
                        }
                        break;
                    }

                case '(':
                    {
                        while (current() != '}' && current() != ')')
                        {
                            next();
                        }
                        break;
                    }

                case '[':
                    {
                        while (current() != '}' && current() != ']')
                        {
                            next();
                        }
                        break;
                    }
                default:
                    {
                        if(char.IsNumber(current()) || current() == '.' || char.IsWhiteSpace(current()) || !char.IsLetter(current())) {
                            next();
                            break;
                        }


                        StringBuilder sb = new();
                        while(current() != ' ')
                        {
                            sb.Append(current());
                            next();
                        }

                        // Debug.Print($"To be evaled: {sb}");

                        SAN san = new();

                        try
                        {
                            san = new SAN(sb.ToString());
                        }
                        catch(Exception)
                        {
                            next();
                            break;
                        }

                        Debug.Print(san.ToString());

                        yield return consume(
                            TokenType.NOTATION, san);

                        break;
                    }

            }
        }
    }
}
