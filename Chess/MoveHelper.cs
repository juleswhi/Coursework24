using Chess;
using Chess.BoardRepresentation;


namespace ChessMasterQuiz.Chess;

public static class MoveHelper
{

    public static Board? CurrentBoard = null;

    public static bool CheckIfPieceOnSquare(SAN location)
    {
        foreach(var piece in CurrentBoard.Pieces)
        {
            if(piece.Location == location)
            {
                return true;
            }
        }

        return false;
    }

    public static bool CheckIfCheck()
    {
        return false;
    }

    public static IEnumerable<Piece> GetPieceThatCouldMove(SAN location)
    {
        if(CurrentBoard is null)
        {
            throw new Exception("CurrentBoard must not be null");
        }

        ReadOnlySpan<Piece> pieces = CurrentBoard.Pieces.ToArray().AsSpan();

        Func<SAN, SAN, Board, bool> validateMove;
        for (int i = 0; i < pieces.Length; i++)
        {
            validateMove = pieces[i] switch
            {
                { Type: PieceType.PAWN } => PawnMove,
                { Type: PieceType.KNIGHT } => KnightMove,
                { Type: PieceType.BISHOP } => BishopMove
            };

            if (validateMove is Func<SAN, SAN, Board, bool> meth)

            if (meth(pieces[i].Location, location, CurrentBoard))
            {
                yield return pieces[i];
            }

        }
    }

    public static bool PawnMove(SAN start, SAN destination, Board? board = null)
    {
        if(board is null && CurrentBoard is null)
        {
            throw new Exception("Board must be instantiated");
        }

        if(board is Board b)
        {
            CurrentBoard = b;
        }

        if (CheckIfPieceOnSquare(destination) )
        {
            if ((destination.Item1 == start.Item1 + 1
             || destination.Item1 == start.Item1 - 1)
             && destination.Item2 == start.Item2 + 1
             )
            {
                return true;
            }
        }

        if (start.Square.Item2 == destination.Square.Item2 + 1 &&
            start.Square.Item1 == destination.Square.Item1)
        {
            if(!CheckIfPieceOnSquare(destination))
            {
                return true;
            }
        }

        if (start.Square.Item2 == destination.Square.Item2 + 2 &&
            start.Square.Item1 == destination.Square.Item1)
        {
            if( !CheckIfPieceOnSquare(destination))
            {
                return true;
            }
        }

        return false;
    }

    public static bool KnightMove(SAN start, SAN destination, Board? board = null)
    {
        return false;
    }

    public static bool BishopMove(SAN start, SAN destination, Board? board = null)
    {
        return false;
    }


}
