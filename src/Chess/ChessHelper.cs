using static ChessMasterQuiz.Chess.ChessPieces;

namespace Chess;
public enum Colour
{
    White = 1,
    Black = 2
}

public record struct Notation(char File, int Rank) : IEquatable<SAN>, IEquatable<string>
{
    public override string ToString()
    {

        var a = typeof(Notation).GetProperty("File");


        return $"{File}{Rank}";
    }

    public static Notation From((char, int) location)
    {
        return new Notation(location.Item1, location.Item2);
    }

    public static Notation From(string location)
    {
        if (location.Length != 2)
        {
            return default;
        }

        return new Notation(location[0], int.Parse(location[1].ToString()));
    }

    public static Notation From(char file, int rank)
    {
        return new Notation(file, rank);
    }

    public bool Equals(SAN? other)
    {
        return ToString() == other?.GetNotation();
    }

    public bool Equals(string? other)
    {
        return ToString() == other;
    }
}

public static class ChessHelper
{


    public static Image GetImage(this Piece piece)
    {
        return piece.Type switch
        {
            PAWN => piece.Colour == White ? WhitePawn : BlackPawn,
            KNIGHT => piece.Colour == White ? WhiteKnight : BlackKnight,
            BISHOP => piece.Colour == White ? WhiteBishop : BlackBishop,
            ROOK => piece.Colour == White ? WhiteRook : BlackRook,
            QUEEN => piece.Colour == White ? WhiteQueen : BlackQueen,
            KING => piece.Colour == White ? WhiteKing : BlackKing,
            _ => WhitePawn
        };
    }

    public static IEnumerable<T> From<T>(params T[] nums)
    {
        foreach (var n in nums)
        {
            yield return n;
        }
    }


    public static PieceType GetPiece(this char c)
    {
        switch (c.ToString().ToLower())
        {
            case "n":
                return KNIGHT;
            case "b":
                return BISHOP;
            case "r":
                return ROOK;
            case "q":
                return QUEEN;
            case "K":
                return KING;
        }

        return PAWN;
    }

    public static char GetChar(this PieceType type)
    {
        return type switch
        {
            PAWN => ' ',
            KNIGHT => 'N',
            BISHOP => 'B',
            ROOK => 'R',
            QUEEN => 'Q',
            KING => 'K',
            _ => '_'

        };
    }

    public static Dictionary<char, PieceType> CharToNotation = new()
    {
        { 'p', PAWN },
        { 'n', KNIGHT },
        { 'b', BISHOP },
        { 'r', ROOK },
        { 'q', QUEEN },
        { 'k', KING },
        { 'P', PAWN },
        { 'N', KNIGHT },
        { 'B', BISHOP },
        { 'R', ROOK },
        { 'Q', QUEEN },
        { 'K', KING }
    };

    public static Dictionary<PieceType, char> NotationToChar = new()
    {
        { PAWN , 'p'},
        { KNIGHT , 'n'},
        { BISHOP , 'b'},
        { ROOK , 'r'},
        { QUEEN , 'q'},
        { KING , 'k'},
        { PAWN , 'P'},
        { KNIGHT , 'N'},
        { BISHOP , 'B'},
        { ROOK , 'R'},
        { QUEEN , 'Q'},
        { KING , 'K'}
    };


    public static Point GetCenter(this Image image, Point location, Size size)
    {
        var imageSize = image.Size;

        PointF midpoint = new(
            location.X + (float)0.5 * size.Width,
            location.Y + (float)0.5 * size.Height
            );

        PointF accountForImage = new(
            midpoint.X - (float)0.5 * imageSize.Width,
            midpoint.Y - (float)0.5 * imageSize.Height
            );


        return Point.Round(accountForImage);
    }


    public static List<Piece> PopulatePieces()
    {
        List<Piece> Pieces = new();
        Pieces.AddRange(

            Enumerable.Range(1, 2)
            .Select(x =>
                Enumerable.Range(1, 8)
                    .Select(y => new Piece(
                        PAWN, Notation.From((char)(y + 96), x == 1 ? 2 : 7), x == 1 ? White : Black)
                        ).ToList()).Aggregate((x, y) =>
                        {
                            y.AddRange(x);
                            return y;
                        })
                );

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(1, 8).Select(
                    x => new Piece(ROOK, Notation.From((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));


        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(2, 7).Select(
                    x => new Piece(KNIGHT, Notation.From((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));


        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(3, 6).Select(
                    x => new Piece(BISHOP, Notation.From((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>
                    new Piece(KING, Notation.From('e', (colour == 1 ? 1 : 8)), (Colour)colour))
            );

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>
                    new Piece(QUEEN, Notation.From('d', (colour == 1 ? 1 : 8)), (Colour)colour))
            );

        foreach (var piece in Pieces)
        {
            if (piece.Location.Rank == 9)
            {
                Pieces.Remove(piece);
            }
        }



        return Pieces;
    }


}
