using ChessMasterQuiz.Forms;
using ChessMasterQuiz.QuestionDir;
using Chess.BoardRepresentation;
using Chess;
using System.Diagnostics;
using ChessMasterQuiz.Misc;
using ChessMasterQuiz.Chess;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        if(context is null || context.Count() == 0)
        {
            // Grab logged in user
            User.User? loggedIn = ActiveUser;
            if(loggedIn is User.User current)
            {
                pBoxProfile.Image = User.User.ProfilePictures[current.ImageIndex];
            }
            return;
        }
        //Grab user
        User.User? user = context.FirstOrDefault(x => x.tag == USER)!.data as User.User;
        if(user is User.User u)
        {
            pBoxProfile.Image = User.User.ProfilePictures[u.ImageIndex];
        }
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
            ActiveUser!,
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

    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        MoveHelper.CurrentBoard?.StopGame();
        ActivateForm<formAddQuestion>();
    }
}
