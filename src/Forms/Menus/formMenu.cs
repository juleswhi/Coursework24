using ChessMasterQuiz.Forms;
using ChessMasterQuiz.Forms.Admin;
using ChessMasterQuiz.Forms.Menus;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    private User? _user = null;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        var userContext = (User?)context.GetFirst(USER);

        if (userContext is null)
        {
            userContext = ActiveUser;
        }

        _user = userContext!;

        if (_user.Type != UserType.ADMIN)
        {
            btnSettings.Hide();
        }

        pBoxProfile.Image = User.ProfilePictures[_user!.ImageIndex];
    }

    public formMenu()
    {
        InitializeComponent();

        pBoxProfile.BackgroundImageLayout = ImageLayout.Stretch;
        pBoxProfile.SizeMode = PictureBoxSizeMode.CenterImage;

        Board board = new();

        PgnReader reader = new();

        reader.FromBytes(PGNLibrary.Steinitz_Best_Games);
        PGN game = new();

        if (reader.Games.Count != 0)
        {
            game = reader.Games.First();
        }

        board.Location = new Point(300, 25);
        Controls.Add(board);

        board.DisplayGame(game);
    }

    private void pBoxProfile_Click(object sender, EventArgs e)
    {
        // Stop game stops the thread so game stops playing in background
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formUserProfile>((_user!, USER));
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formChooseQuiz>((_user!, USER));
    }

    private void btnLeaderboard_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formLeaderboard>();
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formAdminMenu>();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        ActiveUser!.Logout();
        UpdateUser(ActiveUser!);
        ActivateForm<formLogin>();
    }
}
