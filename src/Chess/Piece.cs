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


    public void Move(string location)
    {
        Notation square = Notation.From(location);
        
        bool legalMove = Type switch
        {
            PieceType.PAWN => MoveHelper.PawnMove(Location, square),
            _ => MoveHelper.PawnMove(Location, square)
        };

        if(!legalMove)
        {
            // Debug.Print("Not Legal Move");
            return;
        }

        // Debug.Print($"Legal Move, {location}");
        Location = square;
        MoveHelper.CurrentBoard?.Invalidate();
    }


    public override string ToString()
    {
        return $"{Colour}{Type}";
    }
}
