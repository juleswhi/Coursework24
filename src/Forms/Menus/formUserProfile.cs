using System.Diagnostics;
using ChessMasterQuiz.Misc;

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

        _user = user;

        lblUsername.Text = user.Username;
        lblAccuracyValue.Text = user.Accuracy.ToString();
        lblQuizCompleteValue.Text = user.QuizesCompleted.ToString();
        lblTopScoreValue.Text = user.HighScore.ToString();
        lblRatingValue.Text = user.Elo.Rating.ToString();

        // pBoxProfileImage.Image = User.ProfilePictures[_user.ImageIndex];
        // pBoxProfileImage.BackgroundImageLayout = ImageLayout.Tile;

        var zoomedImage = new Bitmap(171, 158);

        using Graphics g = pBoxProfileImage.CreateGraphics();

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

        g.DrawImage(User.ProfilePictures[_user.ImageIndex], new Rectangle(pBoxProfileImage.Location, zoomedImage.Size));
        Debug.Print($"Drew image");
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
}
