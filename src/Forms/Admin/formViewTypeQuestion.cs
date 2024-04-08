namespace ChessMasterQuiz.Forms.Admin;

public partial class formViewTypeQuestion : Form
{
    private Board _board = new();

    private List<TypeQuestion> _questions = new();
    private int _questionIndex = 0;
    public formViewTypeQuestion()
    {
        InitializeComponent();
        _board.Location = new Point(100, 10);
        Controls.Add(_board);
        TypeQuestion.ReadQuestions();
        _questions = TypeQuestion.Questions!;

        lblName.Text = _questions[_questionIndex].Answer;
        _board.Pieces = _questions[_questionIndex].Setup!.ToList();
        _board.Invalidate();
    }


    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formAdminMenu>();
    }

    private void btnNextPuzzle_Click(object sender, EventArgs e)
    {
        _questionIndex++;
        if (_questionIndex >= _questions.Count)
        {
            _questionIndex = 0;
        }
        lblName.Text = _questions[_questionIndex].Answer;
        _board.Pieces = _questions[_questionIndex].Setup!.ToList();
        _board.Invalidate();
    }

    private void btnPreviousPuzzle_Click(object sender, EventArgs e)
    {
        _questionIndex--;
        if (_questionIndex <= 0)
        {
            _questionIndex = _questions.Count - 1;
        }
        lblName.Text = _questions[_questionIndex].Answer;
        _board.Pieces = _questions[_questionIndex].Setup!.ToList();
        _board.Invalidate();
    }
}
