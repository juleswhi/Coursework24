using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms.Questions;

public partial class formResult : Form, IContext
{
    public formResult()
    {
        InitializeComponent();
    }

    Control.ControlCollection IContext._controls => Controls;
    public void UseContext(IEnumerable<DCT> context)
    {
        var correct = (int)context.GetFirst(QUESTIONS_CORRECT)!;
        var questionIndex = (int)context.GetFirst(INDEX)!;

        var elo = (int)context.GetFirst(NUMBER)!;

        lblQuestion.Text = $"{correct}/{questionIndex}";
        label1.Text = $"ELO: {ActiveUser?.Elo.PastRatings[^10]} -> {elo}";

        ActiveUser!.QuizesCompleted++;
        WriteUsers();
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
        MainMenu();
    }
}
