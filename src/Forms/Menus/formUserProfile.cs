namespace ChessMasterQuiz.Forms;

public partial class formUserProfile : Form, IContext
{
    public formUserProfile()
    {
        InitializeComponent();
    }

    private User? _user;
    public void UseContext(IEnumerable<DataContextTag> context)
    {
        User? user = (User)context.Get(USER).First();

        if (user is null)
        {
            user = ActiveUser!;
        }

        lblNewPasswordInvalid.Hide();
        lblOldPasswordIncorrect.Hide();

        _user = user;

        lblUsername.Text = user.Username;
        lblAccuracyValue.Text = user.Accuracy.ToString();
        lblQuizCompleteValue.Text = user.QuizesCompleted.ToString();
        lblTopScoreValue.Text = user.HighScore.ToString();
        lblRatingValue.Text = user.Elo.Rating.ToString();

        pBoxProfileImage.Image = User.ProfilePictures[_user.ImageIndex];
        pBoxProfileImage.BackgroundImageLayout = ImageLayout.Tile;
        pBoxProfileImage.SizeMode = PictureBoxSizeMode.CenterImage;
    }

    private void lblMainMenu_Click(object sender, EventArgs e)
    {
        WriteUsers();
        ActivateForm<formMenu>((_user!, USER));
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (_user is null)
        {
            return;
        }

        if (_user.ImageIndex == User.ProfilePictures.Count - 1)
        {
            _user.ImageIndex = 0;
        }
        else
        {
            _user.ImageIndex++;
        }

        pBoxProfileImage.Image = User.ProfilePictures[_user.ImageIndex];

        WriteUsers();
    }

    private void btnChangePassword_Click(object sender, EventArgs e)
    {
        string? old = txtBoxOldPassword.Text;
        string? @new = txtBoxNewPassword.Text;


        if (!old.VerifyPassword(_user!))
        {
            lblOldPasswordIncorrect.Show();
            return;
        }

        (bool valid, var _) = @new.Validate(ValidationType.PASSWORD);

        if (_user!.Type == UserType.USER && !valid)
        {
            lblNewPasswordInvalid.Show();
            return;
        }

        Password hashedPassword = @new.Hash();

        _user!.Password = hashedPassword;

        UpdateUser(_user!);
    }
}
