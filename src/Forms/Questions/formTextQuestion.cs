using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.QuestionDir;

public partial class formTextQuestion : Form, IContext
{
    private readonly List<Button> _buttons;
    private TextQuestion? _tq = null;
    public formTextQuestion()
    {
        InitializeComponent();

        // Buttons 
        // C# 12 Collection Initializer
        _buttons = [
            btnAnswer1,
            btnAnswer2,
            btnAnswer3,
            btnAnswer4
            ];


        // Ensure that each button has a click delegate attached

        // This delegate should check if the answer is correct, and then open the next question
        foreach (var b in _buttons)
        {
            b.Click += (s, e) =>
            {
                if (OnAnswered is Action<bool, int> answer)
                {
                    var ans = _buttons.IndexOf(b) == _tq?.A?.Index;
                    answer(ans, _tq!.Rating);
                }
            };
        }
    }

    public Action<bool, int> OnAnswered { get; set; } = EmptyActionGeneric<bool, int>();

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        var questionData = context.GetFirst(QUESTION) as TextQuestion;
        if (questionData is TextQuestion q)
        {
            _tq = q;
        }

        if (questionData is null)
        {
            ActivateForm<formMenu>();
        }

        for (int i = 0; i < _buttons.Count; i++)
        {
            if (_buttons[i] is null)
            {
                continue;
            }

            if (questionData?.A?.Answers.Count <= i)
            {
                continue;
            }

            _buttons[i].Text = questionData?.A?.Answers[i];
        }

        lblQuestion.Text = questionData?.Q;

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

        Debug.Print($"OnAnswered is not null");

        OnAnswered += (Action<bool, int>)onAnswered!;

        lblQuestion.Location = new Point((Width / 2) - (lblQuestion.Width / 2), lblQuestion.Location.Y);
    }
}
