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
    public Piece(PieceType type, SAN location, Colour colour)
    {
        Type = type;
        Location = location;
        Colour = colour;
    }
    public Piece(PieceType type, (char, int) location, Colour colour)
    {
        Type = type;
        Location = SAN.From($"{location.Item1}{location.Item2}");
        Colour = colour;
    }

    public PieceType Type { get; set; }
    public SAN Location { get; set; }
    public Colour Colour { get; set; }


    public void Move(SAN location)
    {
        bool legalMove = Type switch
        {
            PieceType.PAWN => MoveHelper.PawnMove(Location, location),
            _ => MoveHelper.PawnMove(Location, location)
        };

        if(!legalMove)
        {
            Debug.Print("Not Legal Move");
            return;
        }

        Debug.Print($"Legal Move, {location}");
        Location = location;
    }


    public override string ToString()
    {
        return $"{Colour}{Type}";
    }
}
