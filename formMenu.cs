using static ChessMasterQuiz.ContextTagType;
using static ChessMasterQuiz.Helpers.UserHelper;
using static ChessMasterQuiz.Helpers.ControlHelper;
using ChessMasterQuiz.Forms;
using ChessMasterQuiz.QuestionDir;
using ChessMasterObjectNotation;
using Chess.BoardRepresentation;
using Chess;
using System.Diagnostics;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        // Get Random Chess Game

    }

    public formMenu()
    {
        InitializeComponent();

        pBoxProfile.BackgroundImageLayout = ImageLayout.Stretch;
        pBoxProfile.Image = Chess.ChessPieces.WhitePawn;
        pBoxProfile.SizeMode = PictureBoxSizeMode.CenterImage;

        Board board = new Board();

        PgnReader reader = new PgnReader();

        // reader.FromBytes(PGNLibrary.Steinitz_Best_Games);

        board.Location = new Point(300, 25);
        Controls.Add(board);

        PGN pgn = PGN.From(
            new List<(SAN, SAN)>()
            {
                { (SAN.FromString("e4"), SAN.FromString("e5") ) }
            }
            );

        board.DisplayGame(pgn);

    }

    private void pBoxProfile_Click(object sender, EventArgs e)
    {
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
        ActivateForm<formAddQuestion>();
    }
}
