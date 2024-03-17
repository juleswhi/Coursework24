using System.Diagnostics;
using Chess.BoardRepresentation;

namespace ChessMasterQuiz.Forms.Admin;

public partial class formViewPuzzles : Form
{
    private Board _board = new();

    private List<Puzzle> _puzzles = new();
    public formViewPuzzles()
    {
        InitializeComponent();
        _board.Location = new Point(100, 10);
        Controls.Add(_board);

        _puzzles = Puzzle.Puzzles;

        IteratePuzzle(true);
    }

    private int _puzzleIndex = -1;
    private void IteratePuzzle(bool forwards)
    {
        if (forwards)
        {
            if (_puzzleIndex == _puzzles.Count - 1)
            {
                _puzzleIndex = -1;
            }
            _puzzleIndex++;
        }
        else
        {
            if (_puzzleIndex == 0)
            {
                _puzzleIndex = _puzzles.Count;
            }
            _puzzleIndex--;
        }


        if (_puzzles[_puzzleIndex].Setup is IEnumerable<Piece> pieces)
        {
            Debug.Print($"Setting board to pieces");
            _board.Pieces.Clear();
            _board.Pieces = pieces.ToList();
        }
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formAdminMenu>();
    }

    private void btnNextPuzzle_Click(object sender, EventArgs e)
    {
        IteratePuzzle(true);
        Debug.Print($"Previous Puzzle: Index: {_puzzleIndex}");
    }

    private void btnPreviousPuzzle_Click(object sender, EventArgs e)
    {
        IteratePuzzle(false);
        Debug.Print($"Previous Puzzle: Index: {_puzzleIndex}");
    }
}
