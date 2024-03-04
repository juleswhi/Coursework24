using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms;

public partial class formUserProfile : Form, IContext
{
    public formUserProfile()
    {
        InitializeComponent();
    }

    Control.ControlCollection IContext._controls => Controls;
    private User.User _user;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        User.User? user = context.FirstOrDefault(x => x.tag! == USER)!.data! as User.User;
        if (user is null)
        {
            return;
        }

        _user = user;

        lblUsername.Text = user.Name;
        lblAccuracyValue.Text = user.Accuracy.ToString();
        lblQuizCompleteValue.Text = user.QuizesCompleted.ToString();
        lblTopScoreValue.Text = user.HighScore.ToString();
        lblRatingValue.Text = user.Elo.Rating.ToString();

        if(_user is User.User u)
        {
            pBoxProfileImage.Image = User.User.ProfilePictures[u.ImageIndex];
            pBoxProfileImage.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void pBoxProfileImage_Click(object sender, EventArgs e)
    {

    }

    private void lblMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (_user.ImageIndex == User.User.ProfilePictures.Count - 1)
        {
            _user.ImageIndex = 0;
        }
        else _user.ImageIndex++;

        pBoxProfileImage.Image = User.User.ProfilePictures[_user.ImageIndex];
    }
}
