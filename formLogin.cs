using static FamousLakesQuiz.Helper;
namespace FamousLakesQuiz;

public partial class formLogin : Form
{
    private List<DataContextTag> _context = new();
    public formLogin()
    {
        InitializeComponent();
        Resize += onResize;
        btnRegister.Click += (s, e) =>
        {
            Main.Activate<formRegister>(new DataContextTag(txtBoxEmailRegister.Text, "email"));
        };
    }

    private void UseContext(IEnumerable<DataContextTag> context) 
    {
        /*
        var dcts = context.ToDCT();

        foreach(var dct in dcts)
        {
            var control = Controls.OfType<TextBox>().FindTag(dct.tag);
            if (control is null) continue;

            (control as TextBox)!.PlaceholderText = (string)dct.data;
        }
        */

        txtBoxEmail.PlaceholderText = "CONTEXT";

    }

    private void onResize(object? sender, EventArgs e)
    {
        lblLogin.Center()(X);
        txtBoxEmail.Center()(X);
        txtBoxPassword.Center()(X);
        btnLogin.Center()(X);

        lblNewQuiz.Center()(X);

        txtBoxEmailRegister.Center()(X);
        txtBoxEmailRegister.Left -= 55;

        btnRegister.Center()(X);
        btnRegister.Left += 90;
    }
}
