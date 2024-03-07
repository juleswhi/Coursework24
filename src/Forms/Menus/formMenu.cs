using ChessMasterQuiz.Forms;
using ChessMasterQuiz.QuestionDir;
using Chess.BoardRepresentation;
using Chess;
using ChessMasterQuiz.Misc;
using ChessMasterQuiz.Chess;
using ChessMasterQuiz.Forms.Menus;
using ChessMasterQuiz.Forms.Questions;
using System.Diagnostics;

namespace ChessMasterQuiz;

public partial class formMenu : Form, IContext
{
    Control.ControlCollection IContext._controls => Controls;
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

        questions.Shuffle();

        questions = questions.Take(10).ToList();

        int questionIndex = 0;
        int questionsCorrect = 0;

        var onAnswer = EmptyActionGeneric<bool, int>();

        onAnswer += (bool correct, int elo) =>
        {
            if (correct) questionsCorrect++;

            if(_user is User user)
            {
                if (elo != -1)
                {
                    Debug.Print($"NEW ELO MATCH: {user.Elo}, QUESTION ELO: {elo}");
                    ELO.Match(user.Elo, correct ? ELO.MatchupResult.WIN : ELO.MatchupResult.LOSS, elo);
                    Debug.Print($"RESULTANT RATING: {user.Elo}");
                }
            }

            if (questionIndex >= questions.Count)
            {
                // Go to exit screen
                ActivateForm<formResult>(
                    new DataContextTag(questionsCorrect, QUESTIONS_CORRECT),
                    new DataContextTag(questionIndex, INDEX),
                    new DataContextTag(_user?.Elo.Rating!, NUMBER)
                    );
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

        onAnswer(false, -1);
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
