using System.Diagnostics;
using static Chess.ChessHelper;
namespace Chess;

public class SAN
{

    public int Castling { get; set; }
    public bool Capturing { get; set; } = false;
    public bool Check { get; set; } = false;
    public bool CheckMate { get; set; } = false;
    public (char, int) PawnCapturing { get; set; }
    public PieceType Piece { get; set; }
    public char? SpecifyPiece { get; set; }
    public PieceType? IsQueening { get; set; } = null;
    public (char, int) Square { get; set; }


    // This ToString override is used to print the SAN in proper notation

    public override string ToString() =>
        GetNotation().Trim();
    public string GetNotation()
    {

        if(Castling == 1)
        {
            return "O-O";
        }
        else if(Castling == -1)
        {
            return "O-O-O";
        }

        return $"{Piece.GetChar()}" +
        $"{(SpecifyPiece is null ? "" : SpecifyPiece)}" +
        $"{(Capturing && Piece == PieceType.PAWN ? (
            PawnCapturing.Item2 == -1 ? $"{PawnCapturing.Item1}" : $"{PawnCapturing.Item2}"
            ) : "")}" +
        $"{(Capturing ? "x" : "")}" +
        $"{Square.Item1}" +
        $"{Square.Item2}" +
        $"{(IsQueening == null ? "" : $"={((PieceType)IsQueening).GetChar()}")}";

    }

    public SAN(string str)
    {
        FromString(str);
    }

    public SAN()
    {
    }

    public void FromString(string str)
    {
        // ed
        // exd4
        // Nd4
        // Nxd4

        if(str.Count(x => x == 'O') == 2)
        {
            Castling = 1;
            return;
        }
        else if(str.Count(x => x == 'O') == 3)
        {
            Castling = -1;
            return;
        }



        if (str.Contains('x'))
        {
            Capturing = true;
        }

        if(str.Contains('+'))
        {
            Check = true;
        }

        if(str.Contains('#'))
        {
            Check = true;
            CheckMate = true;
        }

        // CharToNotation.TryGetValue(str[0], out PieceType p);
        if (char.IsUpper(str[0]))
        {
            Piece = str[0].GetPiece();
        }
        else if(Capturing)
        {
            PawnCapturing = (str[0], -1);
            Piece = PieceType.PAWN;
        }
        else
        {
            Piece = PieceType.PAWN;
        }

        int numLocation = str.IndexOfAny("123456789".ToArray());

        char file = str[numLocation - 1];
        char rank = str[numLocation];

        Square = (
            file,
            int.Parse(rank.ToString())
            );
    }
}
