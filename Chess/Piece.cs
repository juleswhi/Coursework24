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
    public PieceType Type { get; set; }
    public SAN Location { get; set; }
    public Colour Colour { get; set; }


    public void Move((char, int) location)
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
    public void Move(char rank, int file)
    {
        Move((rank, file));
    }


    public override string ToString()
    {
        return $"{Colour}{Type}";
    }
}
