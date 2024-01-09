namespace FamousLakesQuiz;
public record Answer(IEnumerable<string> Answers, int index);
public enum QuestionType
{
    Text,
    Map
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
#pragma warning disable
    public int CompareTo(Question other)
    {
        return (int)other.Difficulty.CompareTo((int)Difficulty);
    }
    public bool Equals(Question other)
    {
        return other.Name == Name;
    }
#pragma warning enable
}
public class TextQuestion : Question
{
    public QuestionType Type { get; init; }
    public string Name { get; init; }
    public Difficulty Difficulty { get; init; }
    public string Q { get; set; }  
    public Answer A { get; set; }
}
