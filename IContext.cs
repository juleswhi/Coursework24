using static ChessMasterQuiz.Helpers.ControlHelper;
namespace ChessMasterQuiz;


/// <summary>
/// Record type for Data-Context Tag Pair
/// </summary>
/// <param name="data">Object of data</param>
/// <param name="tag">Tag to identify the data</param>
public record DataContextTag(object data, string tag);

interface IContext
{
    protected Control.ControlCollection _controls { get; }
    public void UseContext(IEnumerable<DataContextTag> context) 
    {
        foreach(var dct in context)
        {
            IEnumerable<Control> controls = _controls.OfType<TextBox>().FindPlaceHolder(dct.tag);
            if (controls is null || controls.Count() < 1) continue;

            foreach(var control in controls)
            {
                (control as TextBox)!.PlaceholderText = (string)dct.data;
            }
        }
    }
}
