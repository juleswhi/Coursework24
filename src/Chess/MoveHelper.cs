namespace Chess;

public static class MoveHelper
{
    // Holds a reference to the chess board that is being displayed at the current moment
    public static Board? CurrentBoard = null;

    public static bool CheckIfPieceOnSquare(Notation location)
    {
        if (CurrentBoard is Board board)
        {
            foreach (var piece in board.Pieces)
            {
                if (piece.Location == location)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool SquareIsNotation(Notation square, Notation move)
    {
        return square == move;
    }

    public static bool CheckIfCheck()
    {
        return false;
    }

    public static IEnumerable<Piece> GetPieceThatCouldMove(Notation location)
    {
        if (CurrentBoard is null)
        {
            throw new Exception("CurrentBoard must not be null");
        }

        List<Piece> pieces = CurrentBoard.Pieces;

        Func<Notation, Notation, Board, bool> validateMove;

        for (int i = 0; i < pieces.Count; i++)
        {
            validateMove = pieces[i] switch
            {
                { Type: PieceType.PAWN } => PawnMove,
                { Type: PieceType.KNIGHT } => KnightMove,
                { Type: PieceType.BISHOP } => BishopMove,
                _ => PawnMove
            };

            if (validateMove is Func<Notation, Notation, Board, bool> meth)
            {
                if (meth(pieces[i].Location, location, CurrentBoard))
                {
                    yield return pieces[i];
                }
            }
        }
    }

    public static bool PawnMove(Notation start, Notation destination, Board? board = null)
    {
        if (board is null && CurrentBoard is null)
        {
            throw new Exception("Board must be instantiated");
        }

        if (board is Board b)
        {
            CurrentBoard = b;
        }


        return true;
    }

    public static bool KnightMove(Notation start, Notation destination, Board? board = null)
    {
        return false;
    }

    public static bool BishopMove(Notation start, Notation destination, Board? board = null)
    {
        return false;
    }


}
