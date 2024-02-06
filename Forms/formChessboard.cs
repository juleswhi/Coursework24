using Chess.BoardRepresentation;

namespace ChessMasterQuiz.Forms;

public partial class formChessboard : Form
{
    public formChessboard()
    {
        InitializeComponent();

        Board board = new Board();

        Controls.Add(board);
    }
}
