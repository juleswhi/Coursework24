using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms;

public partial class formUserProfile : Form, IContext
{
    public formUserProfile()
    {
        InitializeComponent();
    }

    Control.ControlCollection IContext._controls => Controls;
    private User? _user;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        User? user = (User)context.Get(USER).First();

        if (user is null) 
            user = ActiveUser!;

        _user = user;

        lblUsername.Text = user.Username;
        lblAccuracyValue.Text = user.Accuracy.ToString();
        lblQuizCompleteValue.Text = user.QuizesCompleted.ToString();
        lblTopScoreValue.Text = user.HighScore.ToString();
        lblRatingValue.Text = user.Elo.Rating.ToString();

        pBoxProfileImage.Image = User.ProfilePictures[_user.ImageIndex];
        pBoxProfileImage.SizeMode = PictureBoxSizeMode.CenterImage;
        pBoxProfileImage.BackgroundImageLayout = ImageLayout.Stretch;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void pBoxProfileImage_Click(object sender, EventArgs e)
    {

    }

    private void lblMainMenu_Click(object sender, EventArgs e)
    {
        WriteUsers();
        ActivateForm<formMenu>(new DataContextTag(_user!, USER));
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (_user is null) return;

        if (_user.ImageIndex == User.ProfilePictures.Count - 1)
        {
            _user.ImageIndex = 5;
        }
        else _user.ImageIndex++;

        pBoxProfileImage.Image = User.ProfilePictures[_user.ImageIndex];

        WriteUsers();
    }
}
