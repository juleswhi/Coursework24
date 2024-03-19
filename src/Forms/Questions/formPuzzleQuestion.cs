namespace ChessMasterQuiz.Forms.Questions;

public partial class formPuzzleQuestion : Form, IContext
{
    public formPuzzleQuestion()
    {
        InitializeComponent();
    }

    public Action<bool, int> OnAnswered { get; set; } = EmptyActionGeneric<bool, int>();

    public void UseContext(IEnumerable<DCT> context)
    {
        Puzzle? puzzle = context.GetFirst<Puzzle>();
        if (puzzle is null)
        {
            return; // Error here?
        }
        List<string>? answers = puzzle.Moves;

        lblWinningMove.Text += $"\nfor {(puzzle.ToMove == White ? "white" : "black")}?";

        List<Button> buttons = new()
        {
            btnAnswer1,
            btnAnswer2,
            btnAnswer3,
            btnAnswer4,
        };

        OnAnswered = context.GetFirst<Action<bool, int>>(ACTION)!;

        foreach (var b in buttons)
        {
            b.Click += (s, e) =>
            {
                if (OnAnswered is Action<bool, int> answer)
                {
                    var ans = buttons.IndexOf(b) == puzzle.CorrectMove;

                    answer(ans, puzzle!.Rating);
                }
            };
        }

        if (answers?.Count != buttons.Count)
        {
            return; // Error?
        }

        for (int i = 0; i < answers.Count; i++)
        {
            buttons[i].Text = answers[i];
        }

        label1.Text = $"{context.GetFirst<string>(NUMBER)} / 10";

        Board board = new();
        board.Location = new(30, 30);
        board.Pieces = puzzle.Setup!.ToList();

        Controls.Add(board);
    }
}
