namespace ChessMasterQuiz.Chess;

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
        { 'k', KING }
    };
}
