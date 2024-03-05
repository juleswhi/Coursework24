using ChessMasterQuiz.Forms;
using ChessMasterQuiz.QuestionDir;
using Chess.BoardRepresentation;
using Chess;
using ChessMasterQuiz.Misc;
using ChessMasterQuiz.Chess;
using ChessMasterQuiz.Forms.Menus;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    Control.ControlCollection IContext._controls => Controls;
    private User? _user = null;

    public void UseContext(IEnumerable<DataContextTag> context)
    {

        User? userContext = (User?)context.GetFirst(USER);

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
        // pBoxProfile.Image = Chess.ChessPieces.WhitePawn;
        pBoxProfile.SizeMode = PictureBoxSizeMode.CenterImage;

        Board board = new Board();

        PgnReader reader = new PgnReader();

        reader.FromBytes(PGNLibrary.Steinitz_Best_Games);

        var game = reader.Games.First();

        board.Location = new Point(300, 25);
        Controls.Add(board);

        board.DisplayGame(game);
    }

    private void pBoxProfile_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formUserProfile>(new DataContextTag(
            _user!,
            USER
            ));
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
        // Bring to another play form??
        // Free Play / Competitive
        // Puzzles
        // Generate list of quesitons here

        MoveHelper.CurrentBoard?.StopGame();
        var file = File.ReadAllLines("questions.qon");

        var questions = LonConvert.Deserialize(file);

        int questionIndex = 0;

        var onAnswer = new Action(() => { });

        onAnswer += () =>
        {
            if (questionIndex >= questions.Count)
            {
                // Go to exit screen
                return;
            }

            ActivateForm<formTextQuestion>(
                new DataContextTag(
                    questions[questionIndex++], QUESTION),
                new DataContextTag(
                    questionIndex.ToString(), NUMBER),
                new DataContextTag(
                    onAnswer,
                    ACTION)
                );
        };

        onAnswer();
    }

    private void btnLeaderboard_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formLeaderboard>();
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formAddQuestion>();
    }
}
