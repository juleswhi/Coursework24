namespace Chess;

using static PieceType;

public static class ChessHelper
{
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
