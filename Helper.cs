namespace FamousLakesQuiz;


/// <summary>
/// Record type for Data-Context Tag Pair
/// </summary>
/// <param name="data">Object of data</param>
/// <param name="tag">Tag to identify the data</param>
public record DataContextTag(object data, string tag);
internal static class Helper
{

    /// <summary>
    /// Reference to Main Form with correct Typing [ Alternative to "(ActiveForm as formMain)" ]
    /// </summary>
    public static formMain Main => (Form.ActiveForm as formMain)!;

    /// <summary>
    /// Returns an Action that will center the Control in the active form 
    /// </summary>
    /// <param name="control">The Control to be centered</param>
    /// <returns>Action to center</returns>
    public static Action Center(this Control control)
    {
        return () =>
        {
            control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
        };
    }

    public static void CreateEquidistantIntervals<T>(this List<T> controls, float distance, int index = 0) where T : Control
    {
        if (index >= controls.Count() - 1) return;
        var bottom = controls[index].Bottom;
        controls[index + 1].Top = bottom + (int)distance;

        controls.CreateEquidistantIntervals(distance, index++);
    }
}
