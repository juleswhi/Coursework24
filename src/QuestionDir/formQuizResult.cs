using static ChessMasterQuiz.Helpers.ControlHelper;
namespace ChessMasterQuiz.QuestionDir;

public partial class formQuizResult : Form
{
    public formQuizResult()
    {
        InitializeComponent();
    }

    private void lblMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }
}
