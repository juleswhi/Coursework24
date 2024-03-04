using static ChessMasterObjectNotation.QuestionType;
using static ChessMasterObjectNotation.Difficulty;
namespace ChessMasterObjectNotation;

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
    public string Name { get; init; } = String.Empty;
    public Difficulty Difficulty { get; init; }

    public int CompareTo(Question? other)
    {
        return (int)other!.Difficulty.CompareTo((int)Difficulty);
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
    }

    public TextQuestion(string q, Answer a) : this()
    {
        Q = q;
        A = a;
    }
    public string Q { get; set; } = string.Empty;
    public Answer? A { get; set; } = null;
}
