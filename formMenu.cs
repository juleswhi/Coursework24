using static ChessMasterQuiz.Helpers.UserHelper;
using static ChessMasterQuiz.Helpers.ControlHelper;
using ChessMasterQuiz.Forms;
using ChessMasterQuiz.QuestionDir;
using System.Diagnostics;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {

    }

    public formMenu()
    {
        InitializeComponent();

        pBoxProfile.BackgroundImageLayout = ImageLayout.Stretch;
        // pBoxProfile.Image = ProfilePictures.ness;
    }

    private void pBoxProfile_Click(object sender, EventArgs e)
    {
        ActivateForm<formUserProfile>(new DataContextTag(
            ActiveUser!,
            "User"
            ));
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
        // Bring to another play form??
        // Free Play / Competitive
        // Puzzles

        var onAnswer = () =>
        {
            Debug.Print("Answer was completed");
        };


        ActivateForm<formTextQuestion>(
            new DataContextTag(
                Helper.TestQuestion, "question"),
            new DataContextTag(
                "1", "number"),
            new DataContextTag(
                onAnswer,
                "action")
            );


    }

    private void btnLeaderboard_Click(object sender, EventArgs e)
    {

    }

    private void btnSettings_Click(object sender, EventArgs e)
    {

    }
}
