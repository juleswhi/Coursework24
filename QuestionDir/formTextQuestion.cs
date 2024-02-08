using System.Diagnostics;
using ChessMasterObjectNotation;
namespace ChessMasterQuiz.QuestionDir;

public partial class formTextQuestion : Form, IContext
{
    private Button[] _buttons;
    public formTextQuestion()
    {
        InitializeComponent();

        // Buttons 
        _buttons = new Button[]
        {
            btnAnswer1,
            btnAnswer2,
            btnAnswer3,
            btnAnswer4
        };

        foreach(var b in _buttons)
        {
            b.Click += (s, e) =>
            {
                Debug.Print("Clicked");
                if (OnAnswered is null)
                {
                    Debug.Print("Answered is null");
                    return;
                }

                OnAnswered!.Invoke();
            };
        }
    }

    public Action OnAnswered { get; set; } = () => { };


    public void FireAnswerCompleted(object sender, EventArgs e)
    {
        Debug.Print("Answer Completed");
    }


    public void UseContext(IEnumerable<DataContextTag> context)
    {
        TextQuestion? questionData = context.FirstOrDefault(
            x => x.tag == "question")?
            .data as TextQuestion;

        if (questionData is null) return;

        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].Text = questionData.A.Answers[i];
        }

        lblQuestion.Text = questionData.Q;

        string? number = context.FirstOrDefault(
            x => x.tag == "number")?
            .data as string;

        if (number is null)
        {
            Debug.Print("Number is null");
            return;
        }

        lblNumber.Text = number;


        var onAnswered = context.FirstOrDefault(
            x => x.tag == "action")?
            .data as Action;

        if(onAnswered is null)
        {
            Debug.Print("OnAnswered not passed through");
            return;
        }

        Debug.Print($"OnAnswered is not null"); 

        OnAnswered += onAnswered;
    }

    Control.ControlCollection IContext._controls => Controls;
}
