using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
    );

public class PgnReader
{
    public List<PGN> Games { get; set; } = new();

    public void FromBytes(params byte[] bytes)
    {
        string str = Encoding.Default.GetString(bytes);

        string[] parts = str.Split(new string[]
        {
            "\r\n\r\n"
        },
        StringSplitOptions.RemoveEmptyEntries);

        // for(int i = 0; i < parts.Length; i+=2)
        {

            PGN pgn = new(string.Empty, string.Empty, default, -1, string.Empty, string.Empty,
                string.Empty, null, null, null, null, null, null, null, new());

            var meta = LexMetadata(parts[0]).Where(x => x.Type == TokenType.KEY 
                                                   || x.Type == TokenType.VALUE).ToList();

            var game = LexGame(parts[1]).ToList();

            // Do something with tokens to convert to PGN 
            MetaTokensToPgn(ref pgn, meta);

            foreach(var token in game)
            {
                Debug.Print($"Token Type: {token.Type}, Token Data: {token.Data}");
            }

            Games.Add(pgn);
        }
    }

    private void MetaTokensToPgn(ref PGN pgn, List<Token> meta)
    {
        var props = typeof(PGN).GetProperties();
        for (int i = 0; i < meta.Count(); i++)
        {
            if (meta[i].Type != TokenType.KEY)
            {
                continue;
            }

            PropertyInfo? property = props.FirstOrDefault(x => x.Name == (string)meta[i].Data!);

            // If the property is found
            if (property is PropertyInfo prop)
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(pgn, meta[i + 1].Data);
                }
                else if (prop.PropertyType == typeof(DateTime?))
                {
                    DateTime date = Convert.ToDateTime(meta[i + 1].Data);
                    prop.SetValue(pgn, date);
                }
                else if (prop.PropertyType == typeof(int?))
                {
                    int num = Convert.ToInt32(meta[i + 1].Data);
                    prop.SetValue(pgn, num);
                }
                else
                {
                    var data = Convert.ChangeType(meta[i + 1].Data, prop.PropertyType);
                    prop.SetValue(pgn, data);
                }
            }

            i++;
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

                        SAN san = new SAN(sb.ToString());

                        Debug.Print(san.ToString());

                        yield return consume(
                            TokenType.NOTATION, san.ToString());

                        break;
                    }

            }
        }
    }
}
