using ChessMasterQuiz.Forms;
using Chess.BoardRepresentation;
using ChessMasterQuiz.Misc;
using ChessMasterQuiz.Chess;
using ChessMasterQuiz.Forms.Menus;
using ChessMasterQuiz.Forms.Admin;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    private User? _user = null;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        var userContext = (User?)context.GetFirst(USER);

        if(userContext is null)
        {
            userContext = ActiveUser;
        }

        _user = userContext!;

        pBoxProfile.Image = User.ProfilePictures[_user!.ImageIndex];

        label1.Text = _user.Username;
    }

    public formMenu()
    {
        InitializeComponent();

        pBoxProfile.BackgroundImageLayout = ImageLayout.Stretch;
        pBoxProfile.SizeMode = PictureBoxSizeMode.CenterImage;

        Board board = new Board();

        PgnReader reader = new PgnReader();

        reader.FromBytes(PGNLibrary.Steinitz_Best_Games);
        PGN game = new();

        if(reader.Games.Count != 0)
        {
            game = reader.Games.First();
        }

        board.Location = new Point(300, 25);
        Controls.Add(board);

        board.DisplayGame(game);
    }

    private void pBoxProfile_Click(object sender, EventArgs e)
    {
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
        ActivateForm<formCreatePuzzle>();
    }
}
