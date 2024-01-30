using LonSerializer;
namespace FamousLakesQuiz.QuestionDir;

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

        if (number is null) return;

        lblNumber.Text = number;

    }

    Control.ControlCollection IContext._controls => Controls;
}
