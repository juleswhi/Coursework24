using static ChessMasterQuiz.Misc.ContextTagType;
using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.QuestionDir;

public partial class formTextQuestion : Form, IContext
{
    private Button[] _buttons;
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

                OnAnswered();
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
            x => x.tag == QUESTION)?
            .data as TextQuestion;

        if (questionData is null) return;

        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].Text = questionData.A!.Answers[i];
        }

        lblQuestion.Text = questionData.Q;

        string? number = context.FirstOrDefault(
            x => x.tag == NUMBER)?
            .data as string;

        if (number is null)
        {
            Debug.Print("Number is null");
            return;
        }

        lblNumber.Text = number;

        var onAnswered = context.FirstOrDefault(
            x => x.tag == ACTION)?
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
