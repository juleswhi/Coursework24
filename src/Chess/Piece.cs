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
    public Piece(PieceType type, Notation location, Colour colour)
    {
        Type = type;
        Location = location;
        Colour = colour;
    }
    public Piece(PieceType type, (char, int) location, Colour colour)
    {
        Type = type;
        Location = Notation.From(location);
        Colour = colour;
    }

    public PieceType Type { get; set; }
    public Notation Location { get; set; }
    public Colour Colour { get; set; }


    public void Move(SAN location)
    {
        bool legalMove = Type switch
        {
            // PieceType.PAWN => MoveHelper.PawnMove(Location, location.Square),
            _ => true
        };

        if(!legalMove)
        {
            // Debug.Print("Not Legal Move");
            return;
        }

        var pieceOnSquare = MoveHelper.CurrentBoard!.Pieces.FirstOrDefault(x => x.Location == location.Square);

        if(pieceOnSquare is Piece p)
        {
            Debug.Print($"Found: {pieceOnSquare.Type} on square {location.Square}");
            p.Remove();
        }

        // Debug.Print($"Legal Move, {location}");
        Location = location.Square;
        MoveHelper.CurrentBoard?.Invalidate();
    }

    public void Remove()
    {
        MoveHelper.CurrentBoard?.Pieces.Remove(this);
    }

    public override string ToString()
    {
        return $"{Colour}{Type}";
    }
}
