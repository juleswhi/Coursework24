using System.Diagnostics;
using ChessMasterQuiz.Chess;

namespace Chess;

// Represents every possible piece type 
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

    // Moves the current piece to a square, `location`
    public void Move(SAN location)
    {
        // Check if piece on square | null if there isnt
        var pieceOnSquare = MoveHelper.CurrentBoard!.Pieces.FirstOrDefault(x => x.Location == location.Square);

        // If the piece should capture or not
        if (pieceOnSquare is Piece p)
        {
            p.Remove();
        }

        // Move the piece
        Location = location.Square;
        // Redraw the current chessboard
        MoveHelper.CurrentBoard?.Invalidate();
    }

    // Get rid of the piece
    public void Remove()
    {
        MoveHelper.CurrentBoard?.Pieces.Remove(this);
    }

    // Pretty print the information ouht
    public override string ToString()
    {
        return $"{Colour} {Type} at {Location}";
    }
}
