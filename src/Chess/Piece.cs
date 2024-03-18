using System.Diagnostics;
using ChessMasterQuiz.Chess;

namespace Chess;

public enum PieceType
{
    PAWN,
    KNIGHT,
    BISHOP,
    ROOK,
    QUEEN,
    KING
}

public class Piece
{
    public Piece(PieceType Type, Notation Location, Colour Colour)
    {
        this.Type = Type;
        this.Location = Location;
        this.Colour = Colour;
    }

    public PieceType Type { get; set; }
    public Notation Location { get; set; }
    public Colour Colour { get; set; }


    public void Move(SAN location)
    {
        var pieceOnSquare = MoveHelper.CurrentBoard!.Pieces.FirstOrDefault(x => x.Location == location.Square);

        if (pieceOnSquare is Piece p)
        {
            Debug.Print($"Found: {pieceOnSquare.Type} on square {location.Square}");
            p.Remove();
        }

        Location = location.Square;
        MoveHelper.CurrentBoard?.Invalidate();
    }

    public void Remove()
    {
        MoveHelper.CurrentBoard?.Pieces.Remove(this);
    }

    public override string ToString()
    {
        return $"{Colour} {Type} at {Location}";
    }
}
