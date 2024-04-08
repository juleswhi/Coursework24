namespace ChessMasterQuiz.Forms.Admin;

public partial class formViewQuestions : Form
{
    readonly List<Label> _answers = new();
    readonly List<TextQuestion> questions = new();
    int _index = 0;
    public formViewQuestions()
    {
        InitializeComponent();

        _answers = [
           lblAnswerOne,
           lblAnswerTwo,
           lblAnswerThree,
           lblAnswerFour,
           ];

        var file = File.ReadAllLines("questions.qon");
        var qs = QonConvert.Deserialize(file);

        foreach (var q in qs)
        {
            if (q is TextQuestion tq)
            {
                questions.Add(tq);
            }
        }

        PopulateFields(questions[_index]);
    }

    private void PopulateFields(TextQuestion question)
    {
        lblQuestionText.Text = $"{question.Q}";

        for (var i = 0; i < _answers.Count; i++)
        {
            _answers[i].Text = $"{_answers[i].Tag?.ToString()} {question.A?.Answers[i]}";
        }
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formAdminMenu>();
    }

    private void btnNextPuzzle_Click(object sender, EventArgs e)
    {
        if (_index >= questions.Count - 1)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }

        PopulateFields(questions[_index]);
    }

    private void btnPreviousQuestion_Click(object sender, EventArgs e)
    {
        if (_index <= 0)
        {
            _index = questions.Count - 1;
        }
        else
        {
            _index--;
        }

        PopulateFields(questions[_index]);
    }
}
