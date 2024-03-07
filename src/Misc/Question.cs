using static ChessMasterQuiz.Misc.QuestionType;
using static ChessMasterQuiz.Misc.Difficulty;

namespace ChessMasterQuiz.Misc;

public record Answer(List<string> Answers, uint Index);

public enum QuestionType
{
    TEXT,
}

public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
}

public abstract class Question : IEquatable<Question>, IComparable<Question>
{
    public QuestionType Type { get; init; }
    public string Name { get; init; } = string.Empty;
    public Difficulty Difficulty { get; init; }
    public int Rating { get; init; } = -1;

    public int CompareTo(Question? other)
    {
        return other!.Difficulty.CompareTo((int)Difficulty);
    }
    public bool Equals(Question? other)
    {
        return other!.Name == Name;
    }
}
public class TextQuestion : Question
{
    public TextQuestion()
    {
        Type = TEXT;
        if(Rating != -1)
        {
            Rating = RatingFromDifficulty(Difficulty);
        }
    }

    public TextQuestion(string q, Answer a) : this()
    {
        Q = q;
        A = a;
    }
    public string Q { get; set; } = string.Empty;
    public Answer? A { get; set; } = null;
}
