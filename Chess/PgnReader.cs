using System.Diagnostics;
using System.Text;

namespace Chess;

public record PGN(
    string Event,
    string Site,
    DateTime Date,
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

        // for(int i = 0; i < parts.Length; i+=2)
        {
            Debug.Print(parts[0]);
            var tokens = LexMetadata(parts[0]);
            foreach(var token in tokens)
            {
                Debug.Print(token.ToString());
            }

        }
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
        LEFT_BRACKET,
        RIGHT_BRACKET,
        LEFT_CURLY,
        RIGHT_CURLY
    }

    class Token(TokenType Type, string? Data)
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

        var consume = (Token token) =>
        {
            _current++;
            return token;
        };

        Type pgnType = typeof(PGN);
        var props = pgnType.GetProperties();

        for(; _current < str.Length;)
        {
            switch(current())
            {

                case '[':
                    yield return consume(new(TokenType.LEFT_BRACKET, null));
                    break;

                case ']':
                    yield return consume(new(TokenType.RIGHT_BRACKET, null));
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

                        yield return consume(new Token(
                            TokenType.VALUE,
                            sb.ToString()
                            ));

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

                        yield return consume(new Token(
                            TokenType.KEY,
                            sb.ToString()
                            ));

                        continue;
                    }
            }
        }


    }

    private void LexGame(string str)
    {
        int _current = 0;

        var next = (int n) => _current += n;
        var peek = () => str[_current++];
        var current = () => str[_current];

        var consume = (Token token) =>
        {
            _current++;
            return token;
        };

        for (; _current < str.Length;)
        {
            switch (current())
            {
                case '{':
                    {
                        while (current() != '}')
                        {
                            next(1);
                        }
                        break;
                    }

                default: break;


            }
        }


    }

    private void Parse()
    {

    }





}
