namespace ChessMasterQuiz.Helpers;


public enum FormatDirection
{
    X = 1,
    Y = 2
}

public static class ControlHelper
{

    public static IEnumerable<object> Get(this IEnumerable<DataContextTag> context, ContextTagType type)
    {
        return context.Where(x => x.tag == type).Select(x => x.data);
    }

    private static readonly Dictionary<Type, ContextTagType> TypeToContextMap = new()
    {
        { typeof(Puzzle), PUZZLE },

    };

    public static T? GetFirst<T>(this IEnumerable<DCT> context)
    {
        var tag = TypeToContextMap[typeof(T)];
        return GetFirst<T>(context, tag);
    }

    public static T? GetFirst<T>(this IEnumerable<DataContextTag> context, ContextTagType type)
    {
        return (T?)context.Where(x => x.tag == type).Select(x => x.data).FirstOrDefault();
    }

    public static object? GetFirst(this IEnumerable<DataContextTag> context, ContextTagType type)
    {
        return context.Where(x => x.tag == type).Select(x => x.data).FirstOrDefault();
    }

    public static void ActivateForm<T>() where T : Form, new()
    {
        // Create the form
        formMain.ChildForm = CreateForm<T>([]);

        // All the boring stuff to display the form
        formMain.ChildForm.TopLevel = false;
        formMain.ChildForm.Dock = DockStyle.Fill;
        formMain.ChildForm.FormBorderStyle = FormBorderStyle.None;
        formMain.ChildForm.Enabled = true;
        formMain.ChildForm.Visible = true;

        var holder = formMain.GetPanelHolder!();

        holder.Controls.Clear();
        holder.Controls.Add(formMain.ChildForm);
        holder.Show();
    }

    public static void ActivateForm<T>(params (object, ContextTagType)[] context) where T : Form, new()
    {
        List<DCT> dct = new();
        foreach (var (obj, tag) in context)
        {
            dct.Add(new(obj, tag));
        }
        // Create the form
        formMain.ChildForm = CreateForm<T>(dct);

        // All the boring stuff to display the form
        formMain.ChildForm.TopLevel = false;
        formMain.ChildForm.Dock = DockStyle.Fill;
        formMain.ChildForm.FormBorderStyle = FormBorderStyle.None;
        formMain.ChildForm.Enabled = true;
        formMain.ChildForm.Visible = true;

        var holder = formMain.GetPanelHolder!();

        holder.Controls.Clear();
        holder.Controls.Add(formMain.ChildForm);
        holder.Show();
    }

    /// <summary>
    /// Creates a Form which passes context through if needed
    /// </summary>
    /// <typeparam name="T">The Type of Form to Create</typeparam>
    /// <param name="context">Enumerable of <c>DataContextTag</c>'s to pass</param>
    /// <returns>The Form Created</returns>
    public static Form CreateForm<T>(IEnumerable<DataContextTag> context) where T : Form, new()
    {
        // Create the Form
        var instance = Activator.CreateInstance<T>()!;

        // Grab the method FROM THE INTERFACE!!
        var method = typeof(IContext).GetMethod("UseContext");

        // If the method exists | The form impl the interface
        if (method is not null && typeof(IContext).IsAssignableFrom(typeof(T)))
        {
            _ = method!.Invoke(instance, new object[] { context });
        }

        // WinFormsScraper.WinFormsScraper.Scrape(instance);

        // Return the form
        return instance;
    }

    /// <summary>
    /// Returns an Action that will center the Control in the active form 
    /// </summary>
    /// <param name="control">The Control to be centered</param>
    /// <returns>Action to center</returns>
    public static void Center(this Control control, params FormatDirection[] directions)
    {
        foreach (var d in directions)
        {
            switch (d)
            {
                case X:
                    control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                    break;
                case Y:
                    control.Location = new((formMain.ChildForm!.Width / 2) - (int)(0.5 * control.Width), control.Location.Y);
                    break;
            };

        }
    }
}
