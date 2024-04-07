using Newtonsoft.Json;
using static ChessMasterQuiz.Misc.QuestionType;

namespace ChessMasterQuiz.Misc;

public record Answer(List<string> Answers, uint Index);

public enum QuestionType
{
    TEXT,
    TYPE
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
    public virtual int Rating { get; init; } = -1;

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
        if (Rating != -1)
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

public class TypeQuestion : Question
{
    public static List<TypeQuestion>? Questions { get; set; } = new();
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;

    public List<Piece> Setup = new();

    private const string _path = $"TypeQuestions.json";

    public TypeQuestion()
    {
        Type = TYPE;
        if (Rating != -1)
        {
            Rating = RatingFromDifficulty(Difficulty);
        }
    }

    public TypeQuestion(string q, string a) : this()
    {
        Question = q;
        Answer = a;
    }

    public static void ReadQuestions()
    {
        Questions = JsonConvert.DeserializeObject<List<TypeQuestion>>(File.ReadAllText(_path));
    }

    public static void WriteQuestions()
    {
        File.WriteAllText(_path, JsonConvert.SerializeObject(Questions));
    }


}
