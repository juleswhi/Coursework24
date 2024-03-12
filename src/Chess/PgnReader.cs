using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Chess;

public record class PGN(
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
    string? FEN,
    List<(SAN, SAN)> Moves
    )
{
    public PGN(List<(SAN, SAN)> moves) : this(string.Empty, string.Empty, null, -1, string.Empty, string.Empty, string.Empty, null, null, null, null, null, null, null, new())
    {
        Moves = moves;
    }

    public PGN() : this(new List<(SAN, SAN)>())
    {

    }
}

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

        // for (int i = 0; i < 10; i += 2)
        {
            PGN pgn = new(string.Empty, string.Empty, default, -1, string.Empty, string.Empty,
                string.Empty, null, null, null, null, null, null, null, new());

            var meta = LexMetadata(parts[0]).Where(x => x.Type == TokenType.KEY
                                                   || x.Type == TokenType.VALUE).ToList();

            var game = LexGame(parts[1]).ToList();

            // Do something with tokens to convert to PGN 
            pgn = MetaTokensToPgn(pgn, meta);

            for (int j = 0; j < game.Count; j += 2)
            {
                (SAN, SAN?) move;

                if (j + 1 == game.Count)
                {
                    move = (SAN.From((string)game[j].Data!), null);
                }

                else
                {
                    move = (SAN.From((string)game[j].Data!), SAN.From((string)game[j + 1].Data!));
                }
                pgn.Moves.Add(move!);
            }

            Games.Add(pgn);
        }

    }

    private PGN MetaTokensToPgn(PGN pgn, List<Token> meta)
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
                if (((string)meta[i + 1].Data!).Contains("?"))
                {
                    continue;
                }
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetMethod?.Invoke(pgn, new object[] { (string)meta[i + 1].Data! });
                }
                else if (prop.PropertyType == typeof(DateTime?))
                {
                    DateTime date = Convert.ToDateTime(meta[i + 1].Data);
                    prop.SetMethod?.Invoke(pgn, new object[] { date });
                }
                else if (prop.PropertyType == typeof(int?))
                {
                    int num = Convert.ToInt32(meta[i + 1].Data);
                    prop.SetMethod?.Invoke(pgn, new object[] { num });
                }
                else
                {
                    var data = Convert.ChangeType(meta[i + 1].Data, prop.PropertyType);
                    prop.SetMethod?.Invoke(pgn, new object[] { data! });
                }
            }

            i++;
        }

        return pgn;
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
        var current = () => str[_current];

        var consume = (TokenType type, object? data = null) =>
        {
            _current++;
            return new Token(type, data);
        };

        Type pgnType = typeof(PGN);
        var props = pgnType.GetProperties();

        for (; _current < str.Length;)
        {
            switch (current())
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
                        while (current() != '"')
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
                        if (!char.IsLetterOrDigit(current()))
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

    private static Dictionary<char, char> SkipperToCloserMap = new()
    {
        { '{', '}' },
        { '(', ')' },
        { '[', ']' },
    };

    private IEnumerable<Token> LexGame(string str)
    {
        int _current = 0;

        var next = (int n = 1) => _current += n;
        var peek = () => str[_current++];
        var current = () =>
        {

            if (_current >= str.Length)
            {
                return str[^1];
            }

            return str[_current];
        };

        var skipto = (char skipper) =>
        {
            int referenceCount = 1;
            while (referenceCount != 0)
            {
                next();
                if (current() == skipper)
                {
                    referenceCount++;
                }
                else if (current() == SkipperToCloserMap[skipper])
                {
                    referenceCount--;
                }

            }
        };

        var consume = (TokenType type, object? data) =>
        {
            _current++;
            return new Token(type, data);
        };

        if (!string.IsNullOrEmpty(str))
        {
            for (; _current < str.Length;)
            {
                switch (current())
                {
                    case '{':
                        skipto('{');
                        break;

                    case '(':
                        skipto('(');
                        break;

                    case '[':
                        skipto('[');
                        break;

                    case '$':
                        next(2);
                        break;

                    default:
                        {
                            if (char.IsNumber(current()) || current() == '.' || char.IsWhiteSpace(current()) || !char.IsLetter(current()))
                            {
                                next();
                                break;
                            }


                            StringBuilder sb = new();
                            while (current() != ' ')
                            {
                                sb.Append(current());
                                next();
                            }

                            yield return consume(
                                TokenType.NOTATION, sb.ToString());

                            break;
                        }

                }
            }
        }
    }
}
