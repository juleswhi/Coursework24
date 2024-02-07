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
    public Piece(PieceType type, (char, int) location, Colour colour)
    {
        Type = type;
        Location = location;
        Colour = colour;
    }
    public PieceType Type { get; set; }
    public (char, int) Location { get; set; }
    public Colour Colour { get; set; }
}
