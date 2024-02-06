namespace Chess;

using static PieceType;

public enum Colour
{
    White,
    Black
} 

public static class ChessHelper
{
    public static PieceType GetPiece(this char c)
    {
        switch(c.ToString().ToLower())
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

    public static char GetChar(this PieceType type) => type switch
    {
        PAWN => ' ',
        KNIGHT => 'N',
        BISHOP => 'B',
        ROOK => 'R',
        QUEEN => 'Q',
        KING => 'K'
    };
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
}
