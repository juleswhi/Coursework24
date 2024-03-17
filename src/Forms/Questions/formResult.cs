using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms.Questions;

public partial class formResult : Form, IContext
{
    public formResult()
    {
        InitializeComponent();
    }

    public void UseContext(IEnumerable<DCT> context)
    {
        var correct = (int)context.GetFirst(QUESTIONS_CORRECT)!;
        var questionIndex = (int)context.GetFirst(INDEX)!;

        var elo = (int)context.GetFirst(NUMBER)!;

        lblQuestion.Text = $"{correct}/{questionIndex}";
        label1.Text = $"{ActiveUser?.Elo.PastRatings[^10]} -> {elo}";
        label1.Center(X);
        lblQuestion.Center(X);

        ActiveUser!.QuizesCompleted++;
        WriteUsers();
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
        MainMenu();
    }
}
