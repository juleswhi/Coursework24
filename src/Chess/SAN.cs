namespace Chess;

public class SAN : IEquatable<SAN>, IEquatable<Notation>
{
    // 0-0 0-0-0
    public int Castling { get; set; }

    // dxe5 Bxe5 Qxf7
    public bool Capturing { get; set; } = false;

    // Rf5+ Qxg6+
    public bool Check { get; set; } = false;

    // Qxf7#
    public bool CheckMate { get; set; } = false;

    // ( 'e', 4 ), ( 'f' 5 )
    public (char, int) PawnCapturing { get; set; }

    // PAWN, QUEEN, BISHOP
    public PieceType Piece { get; set; }

    // Rbf4, f5xg4
    public char? SpecifyPiece { get; set; }

    // f8=Q h1=Q
    public PieceType? IsQueening { get; set; } = null;

    // e4, d5
    public Notation Square { get; set; }

    // d3, g6
    public Notation InitialSquare { get; set; }
    public bool NullMove { get; set; } = false;


    // Print proper notation 
    public override string ToString()
    {
        return GetNotation().Trim();
    }

    // Converts the instance into a standard notation string
    public string GetNotation()
    {
        if (Castling == 1)
        {
            return "O-O";
        }
        else if (Castling == -1)
        {
            return "O-O-O";
        }

        string ret = $"{Piece.GetChar()}" +
        $"{(SpecifyPiece is null ? "" : SpecifyPiece)}" +
        $"{(Capturing && Piece == PieceType.PAWN ? (
            PawnCapturing.Item2 == -1 ? $"{PawnCapturing.Item1}" : $"{PawnCapturing.Item2}"
            ) : "")}" +
        $"{(Capturing ? "x" : "")}" +
        $"{Square.File}" +
        $"{Square.Rank}" +
        $"{(IsQueening == null ? "" : $"={((PieceType)IsQueening).GetChar()}")}";

        return ret.Trim();

    }

    public SAN(string str)
    {
        _ = From(str);
    }

    // Empty constructor
    public SAN()
    {
    }

    // Inspired by functional programming 
    // Converts a SAN string into a SAN object
    public static SAN From(string str)
    {
        SAN san = new();

        if (str == "resigns" || str == "null")
        {
            san.NullMove = true;
            return san;
        }

        if (str.Count(x => x == 'O') == 2)
        {
            san.Castling = 1;
            return san;
        }
        else if (str.Count(x => x == 'O') == 3)
        {
            san.Castling = -1;
            return san;
        }

        if (str.Contains('x'))
        {
            san.Capturing = true;
        }

        if (str.Contains('+'))
        {
            san.Check = true;
        }

        if (str.Contains('#'))
        {
            san.Check = true;
            san.CheckMate = true;
        }

        // CharToNotation.TryGetValue(str[0], out PieceType p);
        if (char.IsUpper(str[0]))
        {
            san.Piece = str[0].GetPiece();
        }
        else if (san.Capturing)
        {
            san.PawnCapturing = (str[0], -1);
            san.Piece = PieceType.PAWN;
        }
        else
        {
            san.Piece = PieceType.PAWN;
        }

        int numLocation = str.IndexOfAny("12345678".ToArray());

        char file = str[numLocation - 1];
        int rank = Convert.ToInt16(str[numLocation].ToString());

        san.Square = Notation.From(file, rank);

        san.InitialSquare = san.GetInitialLocation();

        return san;
    }

    private static int FileNumberFromChar(char file)
    {
        return file switch
        {
            'a' => 1,
            'b' => 2,
            'c' => 3,
            'd' => 4,
            'e' => 5,
            'f' => 6,
            'g' => 7,
            'h' => 8,
            _ => -1
        };
    }

    // This finds out where a piece could have come from based on a singlular SAN and a piece list  
    public Notation GetInitialLocation()
    {
        int PAWN_DIRECTION;

        switch (Piece)
        {
            case PAWN:
                {
                    foreach (var pawn in MoveHelper.CurrentBoard!.Pieces.Where(x => x.Type == PieceType.PAWN))
                    {
                        // Grab current pawn's file + the final file
                        int pawnFile = FileNumberFromChar(pawn.Location.File);
                        int destFile = FileNumberFromChar(Square.File);

                        // If the pawn is white or black - moves different direction
                        PAWN_DIRECTION = pawn.Colour == Colour.White ? -1 : 1;
                        if (pawn.Location.File != Square.File)
                        {
                            continue;
                        }

                        if (pawn.Location.Rank == Square.Rank + PAWN_DIRECTION)
                        {
                            return pawn.Location;
                        }
                        // Pawn can only move two squares if it is on it's inital square
                        else if (pawn.Location.Rank == Square.Rank + PAWN_DIRECTION * 2)
                        {
                            if (pawn.Colour == Colour.White)
                            {
                                if (pawn.Location.Rank != 2)
                                {
                                    continue;
                                }
                            }
                            else if (pawn.Colour == Colour.Black)
                            {
                                if (pawn.Location.Rank != 7)
                                {
                                    continue;
                                }
                            }
                        }

                        // Check all pawn one square moves
                        else if (pawnFile == destFile + 1 || pawnFile == destFile - 1)
                        {
                            if (pawn.Location.Rank + PAWN_DIRECTION == Square.Rank)
                            {
                                return pawn.Location;
                            }
                        }
                        else
                        {
                            // No move found, try again on the next pawn
                            continue;
                        }

                        return pawn.Location;
                    }

                    break;
                }

            case KNIGHT:
                foreach (var knight in MoveHelper.CurrentBoard!.Pieces.Where(x => x.Type == PieceType.KNIGHT))
                {
                    int knightFile = FileNumberFromChar(knight.Location.File);
                    int destFile = FileNumberFromChar(Square.File);

                    // Knight Jumps
                    if (knightFile == destFile + 1 || knightFile == destFile - 1)
                    {
                        if (knight.Location.Rank == Square.Rank + 2 ||
                            knight.Location.Rank == Square.Rank - 2)
                        {
                            return knight.Location;
                        }
                    }
                    else if (knightFile == destFile + 2 || knightFile == destFile - 2)
                    {
                        if (knight.Location.Rank == Square.Rank + 1 ||
                            knight.Location.Rank == Square.Rank - 1)
                        {
                            return knight.Location;
                        }
                    }
                }
                break;

            case BISHOP:
                foreach (var bishop in MoveHelper.CurrentBoard!.Pieces.Where(x => x.Type == BISHOP))
                {
                    int bishopFile = FileNumberFromChar(bishop.Location.File);
                    int destFile = FileNumberFromChar(Square.File);

                    for (int i = 1; i < 8; i++)
                    {
                        // Check in all four directions
                        if (bishopFile + i == destFile && bishop.Location.Rank + i == Square.Rank)
                        {
                            return bishop.Location;
                        }
                        else if (bishopFile - i == destFile && bishop.Location.Rank + i == Square.Rank)
                        {
                            return bishop.Location;
                        }
                        else if (bishopFile - i == destFile && bishop.Location.Rank - i == Square.Rank)
                        {
                            return bishop.Location;
                        }
                        else if (bishopFile + i == destFile && bishop.Location.Rank - i == Square.Rank)
                        {
                            return bishop.Location;
                        }
                    }
                }

                break;
            case QUEEN:
                foreach (var queen in MoveHelper.CurrentBoard!.Pieces.Where(x => x.Type == QUEEN))
                {
                    int queenFile = FileNumberFromChar(queen.Location.File);
                    int destFile = FileNumberFromChar(Square.File);

                    for (int i = 1; i < 8; i++)
                    {
                        // Check in all four directions
                        if (queenFile + i == destFile && queen.Location.Rank + i == Square.Rank)
                        {
                            return queen.Location;
                        }
                        else if (queenFile - i == destFile && queen.Location.Rank + i == Square.Rank)
                        {
                            return queen.Location;
                        }
                        else if (queenFile - i == destFile && queen.Location.Rank - i == Square.Rank)
                        {
                            return queen.Location;
                        }
                        else if (queenFile + i == destFile && queen.Location.Rank - i == Square.Rank)
                        {
                            return queen.Location;
                        }
                    }
                }
                break;
        }

        return new();
    }


    public bool Equals(SAN? other)
    {
        return ToString() == other?.ToString();
    }

    public bool Equals(Notation other)
    {
        return GetNotation() == other.ToString();
    }
}
