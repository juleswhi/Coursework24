namespace ChessMasterQuiz.Forms.Admin;

public partial class formViewPuzzles : Form
{
    private readonly Board _board = new();
    private readonly List<Puzzle> _puzzles = new();
    private int _puzzleIndex = 0;

    public formViewPuzzles()
    {
        InitializeComponent();
        _board.Location = new Point(100, 10);
        Controls.Add(_board);
        Puzzle.CreatePuzzles();
        _puzzles = Puzzle.Puzzles;

        // Grab the pieces from first puzzle and display
        _board.Pieces = _puzzles[_puzzleIndex].Setup!.ToList();
        // Update the board
        _board.Invalidate();
    }


    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formAdminMenu>();
    }

    private void btnNextPuzzle_Click(object sender, EventArgs e)
    {
        // Ensure that index always in bounds
        _puzzleIndex++;
        if (_puzzleIndex >= _puzzles.Count)
        {
            _puzzleIndex = 0;
        }
        _board.Pieces = _puzzles[_puzzleIndex].Setup!.ToList();
        _board.Invalidate();
    }

    private void btnPreviousPuzzle_Click(object sender, EventArgs e)
    {
        // Ensure that index always in bounds
        _puzzleIndex--;
        if (_puzzleIndex <= 0)
        {
            _puzzleIndex = _puzzles.Count - 1;
        }
        _board.Pieces = _puzzles[_puzzleIndex].Setup!.ToList();
        _board.Invalidate();
    }
}
