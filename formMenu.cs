using static ChessMasterQuiz.Helpers.UserHelper;
using static ChessMasterQuiz.Helpers.ControlHelper;
using ChessMasterQuiz.Forms;

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

    }

    private void btnLeaderboard_Click(object sender, EventArgs e)
    {

    }

    private void btnSettings_Click(object sender, EventArgs e)
    {

    }
}
