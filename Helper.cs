namespace FamousLakesQuiz;

public enum FormatDirection
{
    X,
    Y
}

/// <summary>
/// Record type for Data-Context Tag Pair
/// </summary>
/// <param name="data">Object of data</param>
/// <param name="tag">Tag to identify the data</param>
public record DataContextTag(object data, string tag);

internal static class Helper
{

    public static Control? FindTag(this IEnumerable<Control> controls, string tag)
    {
        foreach(var control in controls)
        {
            if (control.Tag is null) continue;
            if ((string)control.Tag == tag) return control;
        }
        return null;
    }

    public static IEnumerable<DataContextTag> ToDCT(this IEnumerable<object> objs)
    {
        List<DataContextTag> dcts = new();
        foreach(var o in objs)
        {
            dcts.Add((DataContextTag)o);
        }
        return dcts;
    }

    /// <summary>
    /// Reference to Main Form with correct Typing [ Alternative to "(ActiveForm as formMain)" ]
    /// </summary>
    public static formMain Main => (Form.ActiveForm as formMain)!;

    /// <summary>
    /// Returns an Action that will center the Control in the active form 
    /// </summary>
    /// <param name="control">The Control to be centered</param>
    /// <returns>Action to center</returns>
    public static Action<FormatDirection> Center(this Control control)
    {
        return (d) =>
        {
            switch(d)
            {
                case X: control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                    break;
                case Y: control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                    break;
            };
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
