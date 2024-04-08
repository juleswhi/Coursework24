using System.Diagnostics;

namespace ChessMasterQuiz.Forms.Questions;

public partial class formTypeQuestion : Form, IContext
{

    private TypeQuestion _question;
    public formTypeQuestion()
    {
        InitializeComponent();

        _question = new();
    }

    public Action<bool, int> OnAnswered { get; set; } = EmptyActionGeneric<bool, int>();

    public void UseContext(IEnumerable<DCT> context)
    {
        var questionData = context.GetFirst(QUESTION) as TypeQuestion;
        if (questionData is TypeQuestion q)
        {
            _question = q;
        }

        if (questionData is null)
        {
            ActivateForm<formMenu>();
        }

        lblQuestion.Text = questionData?.Question;

        var board = new Board();

        board.Location = new Point(20, 20);

        board.Pieces = _question.Setup!.ToList();

        Debug.Print($"Setup board");

        Controls.Add(board);

        var number = context.GetFirst(NUMBER) as string;

        if (number is null)
        {
            ActivateForm<formMenu>();
        }

        lblNumber.Text = $"{number} / 10";

        var onAnswered = context.GetFirst(ACTION);

        if (onAnswered is null)
        {
            ActivateForm<formMenu>();
        }

        OnAnswered += (Action<bool, int>)onAnswered!;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (OnAnswered is Action<bool, int> answer)
        {
            var ans = txtBoxAnswer.Text == _question.Answer;
            answer(ans, _question!.Rating);
        }
    }
}
