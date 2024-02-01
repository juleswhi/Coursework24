using static Chess.ChessHelper;
namespace Chess;

public class SAN
{

    public bool Capturing { get; set; } = false;
    public PieceType Piece { get; set; }
    public char? SpecifyPiece { get; set; }
    public PieceType? IsQueening { get; set; }
    public (char, int) Square { get; set; } 


    public override string ToString() =>
        $"{NotationToChar[Piece]}" +
        $"{(SpecifyPiece is null ? "" : SpecifyPiece)}" +
        $"{(Capturing ? "x" : "")}" +
        $"{Square.Item1}" +
        $"{Square.Item2}" +
        $"{(IsQueening == null ? "" : $"={NotationToChar[(PieceType)IsQueening]}")}";

    public SAN(string str)
    {
        FromString(str);
    }

    public void FromString(string str)
    {
        
    }
}
