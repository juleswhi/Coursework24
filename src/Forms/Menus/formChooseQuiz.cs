using System.Diagnostics;
using ChessMasterQuiz.Forms.Questions;
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
        questions = questions.ToArray().AsSpan().Shuffle().ToList();

        questions = questions.Take(10).ToList();

        int questionIndex = 0;
        int questionsCorrect = 0;

        var onAnswer = EmptyActionGeneric<bool, int>();

        onAnswer += (bool correct, int elo) =>
        {
            if (correct)
            {
                questionsCorrect++;
                if (_user is User u)
                {
                    u.CorrectAnswersInRow++;
                    if (u.CorrectAnswersInRow > u.HighScore)
                    {
                        u.HighScore = u.CorrectAnswersInRow;
                    }
                }
            }
            else
            {
                if (_user is User u)
                    u.CorrectAnswersInRow = 0;
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
                    _user.Accuracy = questionsCorrect * 10;
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
                if (_user is User u)
                {
                    u.CorrectAnswersInRow++;
                    if (u.CorrectAnswersInRow > u.HighScore)
                    {
                        u.HighScore = u.CorrectAnswersInRow;
                    }
                }
            }
            else
            {
                if (_user is User u)
                    u.CorrectAnswersInRow = 0;
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

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }

    private void btnMixed_Click(object sender, EventArgs e)
    {
        List<Question> puzzles = new();

        puzzles.AddRange(Puzzle.Puzzles.ToArray().AsSpan().Shuffle());
        var file = File.ReadAllLines("questions.qon");

        List<TextQuestion> readQuestions = QonConvert.Deserialize(file).Select(x => (TextQuestion)x).ToList();
        IList<TextQuestion> questions = readQuestions.ToArray().AsSpan().Shuffle();

        questions = questions.Take(5).ToList();

        puzzles.AddRange(questions);

        puzzles = puzzles.ToArray().AsSpan().Shuffle().ToList();

        int questionIndex = 0;
        int questionsCorrect = 0;

        var onAnswer = EmptyActionGeneric<bool, int>();

        onAnswer += (bool correct, int elo) =>
        {
            if (correct)
            {
                questionsCorrect++;
                if (_user is User u)
                {
                    u.CorrectAnswersInRow++;
                    if (u.CorrectAnswersInRow > u.HighScore)
                    {
                        u.HighScore = u.CorrectAnswersInRow;
                    }
                }
            }
            else
            {
                if (_user is User u)
                    u.CorrectAnswersInRow = 0;
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

            if (puzzles[questionIndex] is Puzzle)
            {
                ActivateForm<formPuzzleQuestion>(
                    ((puzzles[questionIndex++] as Puzzle)!, PUZZLE),
                    (questionIndex.ToString(), NUMBER),
                    (onAnswer, ACTION)
                    );
            }
            else if (puzzles[questionIndex] is TextQuestion)
            {
                ActivateForm<formTextQuestion>(
                    ((puzzles[questionIndex++] as TextQuestion)!, QUESTION),
                    (questionIndex.ToString(), NUMBER),
                    (onAnswer, ACTION)
                    );
            }
        };

        onAnswer(false, -1);

    }

    private void btnTypingQuestions_Click(object sender, EventArgs e)
    {
        Debug.Print($"HIT THE BUTTON FR");
        TypeQuestion.ReadQuestions();
        var questions = TypeQuestion.Questions;

        if(questions is null)
        {
            Debug.Print($"Questions is null");
            return;
        }

        questions = questions.ToArray().AsSpan().Shuffle().Take(
            questions.Count <= 6 ? questions.Count : 5
            ).ToList();

        var onAnswer = EmptyActionGeneric<bool, int>();

        int questionIndex = 0;
        int questionsCorrect = 0;

        onAnswer += (bool correct, int elo) =>
        {
            if (correct)
            {
                questionsCorrect++;
                if (_user is User u)
                {
                    u.CorrectAnswersInRow++;
                    if (u.CorrectAnswersInRow > u.HighScore)
                    {
                        u.HighScore = u.CorrectAnswersInRow;
                    }
                }
            }
            else
            {
                if (_user is User u)
                    u.CorrectAnswersInRow = 0;
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
                ActivateForm<formResult>(
                    (questionsCorrect, QUESTIONS_CORRECT),
                    (questionIndex, INDEX),
                    (_user?.Elo.Rating!, NUMBER)
                    );
                return;
            }

            ActivateForm<formTypeQuestion>(
                (questions[questionIndex++]!, QUESTION),
                (questionIndex.ToString(), NUMBER),
                (onAnswer, ACTION)
                );
        };

        Debug.Print($"Before answerering");
        onAnswer(false, -1);
        Debug.Print($"After answerering");
    }
}
