namespace FamousLakesQuiz;

public partial class formMain : Form
{
    public static Form? ChildForm { get; set; } = null;
    
    public formMain()
    {
        InitializeComponent();
        Activate<formLogin>();
    }

    public void Activate<T>(params DataContextTag[] context) where T : Form, new()
    {
        // Reflection 
        Type t = typeof(T);
        var ctors = t.GetConstructors();
        var contextConstructor = ctors.Where(x => x.GetParameters().Where(x => x.Name == "context").Count() != 0).Take(0);

        // If found constructor exists and there is actually context
        if(contextConstructor is not null && context.Length > 0)
        {
            ChildForm = _formFactory[(typeof(T), true)](context.ToList());
        } 
        else
        {
            ChildForm = _formFactory[(typeof(T), false)](null);
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

    public void CreateForm<T>() where T : Form, new() {
        Type t = typeof(T);
    }

    Dictionary<(Type, bool),  Func<IEnumerable<DataContextTag>?, Form>> _formFactory = new()
    {
        { (typeof(formLogin), false), (_) => new formLogin() },
        { (typeof(formLogin), true), (o) => new formLogin(o!) },
        { (typeof(formRegister), false), (_) => new formRegister() },
        { (typeof(formRegister), true), (o) => new formRegister(o!) },
    };
}
