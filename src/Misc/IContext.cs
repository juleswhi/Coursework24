namespace ChessMasterQuiz.Misc;

// These represent any data that could be passed through
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
 */
internal interface IContext
{
    // DCT is an alias for DataContextTag 
    public void UseContext(IEnumerable<DCT> context);
}
