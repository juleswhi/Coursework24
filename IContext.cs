using static ChessMasterQuiz.Helpers.ControlHelper;
namespace ChessMasterQuiz;

public enum ContextTagType
{
    QUESTION,
    NUMBER,
    ACTION,
    EMAIL,
    USER
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
    // TODO: Please pleaser please please
    // refactor to remove default implemetnation it fuckingt sucskc
    protected Control.ControlCollection _controls { get; }
    public void UseContext(IEnumerable<DataContextTag> context) 
    {
        foreach(var dct in context)
        {
            IEnumerable<Control> controls = _controls.OfType<TextBox>().FindPlaceHolder(dct.tag.ToString());
            if (controls is null || controls.Count() < 1) continue;

            foreach(var control in controls)
            {
                (control as TextBox)!.PlaceholderText = (string)dct.data;
            }
        }
    }
}
