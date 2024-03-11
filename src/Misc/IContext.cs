using static ChessMasterQuiz.Helpers.ControlHelper;
namespace ChessMasterQuiz.Misc;

public enum ContextTagType
{
    QUESTION,
    QUESTIONS_CORRECT,
    INDEX,
    NUMBER,
    ACTION,
    EMAIL,
    USER,
    PUZZLE
}

/// <summary>
/// Record type for Data-Context Tag Pair
/// </summary>
/// <param name="data">Object of data</param>
/// <param name="tag">Tag to identify the data</param>
public record DataContextTag(object data, ContextTagType tag);

/*
   The IContext interface allows the Context System 
   to ensure that the method is available 
   TYPE SAFETY YEAH!
 */
interface IContext
{
    public void UseContext(IEnumerable<DataContextTag> context);
}
