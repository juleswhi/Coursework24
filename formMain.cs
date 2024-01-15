using static System.Reflection.BindingFlags;
namespace FamousLakesQuiz;

public partial class formMain : Form
{
    public static Form? ChildForm { get; set; } = null;
    
    public formMain()
    {
        InitializeComponent();
        Activate<formLogin>(new DataContextTag[]
        {
            new("Test", "email"),
        });
    }

    public void Activate<T>(params DataContextTag[] context) where T : Form, new()
    {
        // Reflection 
        Type t = typeof(T);
        var methods = t.GetMethod("UseContext");

        // If method exists fr
        if(methods is not null)
        {
            ChildForm = CreateForm<T>(context);
        } 
        else
        {
            ChildForm = new T();
        }

        // All the boring stuff to display the form
        ChildForm.TopLevel = false;
        ChildForm.Dock = DockStyle.Fill;
        ChildForm.FormBorderStyle = FormBorderStyle.None;
        ChildForm.Enabled = true;
        ChildForm.Visible = true;

        panelHolder.Controls.Clear();
        panelHolder.Controls.Add(ChildForm);
        panelHolder.Show();

        Refresh();
    }

    public Form CreateForm<T>(params object[] context) where T : Form, new() {
        var form =  (T)Activator.CreateInstance(typeof(T), args: context)!;
        form.GetType().GetMethod("UseContext", NonPublic | Instance)!.Invoke(form, context);
        return form;
    }

}
