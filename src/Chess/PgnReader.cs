using System.Text;

namespace Chess;

// Represents ONE pgn game
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
    // Holds a list of the currently parsed PGNs
    public List<PGN> Games { get; set; } = new();

    // This method is useful when reading straight from a .resx file
    public void FromBytes(params byte[] bytes)
    {
        string str = Encoding.Default.GetString(bytes);

        // Splitting by double new line
        string[] parts = str.Split(new string[]
        {
            "\r\n\r\n"
        },
        StringSplitOptions.RemoveEmptyEntries);


        PGN pgn = new(string.Empty, string.Empty, default, -1, string.Empty, string.Empty,
            string.Empty, null, null, null, null, null, null, null, new());


        // Lex both parts of the game
        var meta = LexMetadata(parts[0]).Where(x => x.Type == TokenType.KEY
                                               || x.Type == TokenType.VALUE).ToList();

        var game = LexGame(parts[1]).ToList();

        // Do something with tokens to convert to PGN 
        pgn = MetaTokensToPgn(pgn, meta);

        // Convert all the moves into SAN 
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
                    _ = (prop.SetMethod?.Invoke(pgn, new object[] { (string)meta[i + 1].Data! }));
                }
                else if (prop.PropertyType == typeof(DateTime?))
                {
                    DateTime date = Convert.ToDateTime(meta[i + 1].Data);
                    _ = (prop.SetMethod?.Invoke(pgn, new object[] { date }));
                }
                else if (prop.PropertyType == typeof(int?))
                {
                    int num = Convert.ToInt32(meta[i + 1].Data);
                    _ = (prop.SetMethod?.Invoke(pgn, new object[] { num }));
                }
                else
                {
                    var data = Convert.ChangeType(meta[i + 1].Data, prop.PropertyType);
                    _ = (prop.SetMethod?.Invoke(pgn, new object[] { data! }));
                }
            }

            i++;
        }

        return pgn;
    }

    private enum TokenType
    {
        KEY,
        VALUE,
        NOTATION,
        LEFT_BRACKET,
        RIGHT_BRACKET,
        LEFT_CURLY,
        RIGHT_CURLY
    }

    private record struct Token(TokenType Type, object? Data)
    {
        public override string ToString()
        {
            return $"{Type}: {Data ?? ""}";
        }
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
        _ = pgnType.GetProperties();

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
                        _ = next(1);
                        while (current() != '"')
                        {
                            _ = sb.Append(current());
                            _ = next(1);
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
                            _ = next(1);
                            break;
                        }
                        StringBuilder sb = new();
                        while (char.IsLetterOrDigit(current()))
                        {
                            _ = sb.Append(current());
                            _ = next(1);
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

    private static readonly Dictionary<char, char> SkipperToCloserMap = new()
    {
        { '{', '}' },
        { '(', ')' },
        { '[', ']' },
    };

    private IEnumerable<Token> LexGame(string str)
    {
        int _current = 0;

        var next = (int n = 1) => _current += n;
        _ = () => str[_current++];
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
                _ = next();
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
                        _ = next(2);
                        break;

                    default:
                        {
                            if (char.IsNumber(current()) || current() == '.' || char.IsWhiteSpace(current()) || !char.IsLetter(current()))
                            {
                                _ = next();
                                break;
                            }


                            StringBuilder sb = new();
                            while (current() != ' ')
                            {
                                _ = sb.Append(current());
                                _ = next();
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
