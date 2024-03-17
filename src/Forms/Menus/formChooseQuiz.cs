using ChessMasterQuiz.Forms.Questions;
using ChessMasterQuiz.Misc;
using ChessMasterQuiz.QuestionDir;

namespace ChessMasterQuiz.Forms.Menus;

public partial class formChooseQuiz : Form, IContext
{
    private User? _user = null;
    public void UseContext(IEnumerable<DCT> context)
    {
        User? user = context.GetFirst<User>(USER);

        if (user is null)
        {
            user = ActiveUser!;
        }

        _user = user;
    }

    public formChooseQuiz()
    {
        InitializeComponent();
    }

    private void btnWrittenQuestions_Click(object sender, EventArgs e)
    {
        var file = File.ReadAllLines("questions.qon");

        var questions = QonConvert.Deserialize(file);
        questions.Shuffle();

        questions = questions.Take(10).ToList();

        int questionIndex = 0;
        int questionsCorrect = 0;

        var onAnswer = EmptyActionGeneric<bool, int>();

        onAnswer += (bool correct, int elo) =>
        {
            if (correct)
            {
                questionsCorrect++;
            }

            if (_user is User user)
            {
                if (elo != -1)
                {
                    ELO.Match(user.Elo, correct ? ELO.MatchupResult.WIN : ELO.MatchupResult.LOSS, elo);
                }
            }

            if (questionIndex >= questions.Count)
            {
                // Update accuracy
                if (_user?.QuizesCompleted == 0)
                {
                    _user.Accuracy = (int)(questionsCorrect * 10);
                }
                else
                {
                    _user!.Accuracy = (int)((questionsCorrect * 10) + _user.Accuracy) / 2;
                }

                // Go to exit screen
                ActivateForm<formResult>(
                    (questionsCorrect, QUESTIONS_CORRECT),
                    (questionIndex, INDEX),
                    (_user?.Elo.Rating!, NUMBER)
                    );
                return;
            }

            ActivateForm<formTextQuestion>(
                (questions[questionIndex++], QUESTION),
                (questionIndex.ToString(), NUMBER),
                (onAnswer, ACTION)
                );
        };

        onAnswer(false, -1);
    }

    private void btnPuzzles_Click(object sender, EventArgs e)
    {
        List<Puzzle> puzzles = Puzzle.Puzzles;

        int questionIndex = 0;
        int questionsCorrect = 0;

        var onAnswer = EmptyActionGeneric<bool, int>();

        onAnswer += (bool correct, int elo) =>
        {
            if (correct)
            {
                questionsCorrect++;
            }

            if (_user is User user)
            {
                if (elo != -1)
                {
                    ELO.Match(user.Elo, correct ? ELO.MatchupResult.WIN : ELO.MatchupResult.LOSS, elo);
                }
            }

            if (questionIndex >= puzzles.Count)
            {
                ActivateForm<formResult>(
                    (questionsCorrect, QUESTIONS_CORRECT),
                    (questionIndex, INDEX),
                    (_user?.Elo.Rating!, NUMBER)
                    );
                return;
            }

            ActivateForm<formPuzzleQuestion>(
                (puzzles[questionIndex++], PUZZLE),
                (questionIndex.ToString(), NUMBER),
                (onAnswer, ACTION)
                );
        };

        onAnswer(false, -1);
    }


}
