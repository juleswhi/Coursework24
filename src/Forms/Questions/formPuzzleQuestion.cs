using Chess.BoardRepresentation;
using ChessMasterQuiz.Misc;

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
        List<(string, bool)>? answers = puzzle.Moves;

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
                    var ans = buttons.IndexOf(b) == puzzle.Moves.IndexOf(
                        puzzle.Moves.FirstOrDefault(
                        x => x.Item2 == true));

                    answer(ans, puzzle!.Rating);
                }
            };
        }

        if (answers.Count != buttons.Count)
        {
            return; // Error?
        }

        for (int i = 0; i < answers.Count; i++)
        {
            buttons[i].Text = answers[i].Item1;
        }

        Board board = new Board();
        board.Location = new(30, 30);
        board.Pieces = puzzle.Setup.ToList();

        Controls.Add(board);
    }
}
