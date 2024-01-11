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

    public formLogin(IEnumerable<DataContextTag> context) : this()
    {
        _context = context.ToList();

        foreach(var c in Controls.OfType<TextBox>())
        {
            if (c.PlaceholderText is null) continue;
            foreach(var dct in context)
            {
                // Cast to string for value type
                if (c.PlaceholderText.ToLower() != dct.tag) continue;

                c.PlaceholderText = (string)dct.data;
            }
        }

    }

    private void onResize(object? sender, EventArgs e)
    {
        lblLogin.Center()();
        txtBoxEmail.Center()();
        txtBoxPassword.Center()();
        btnLogin.Center()();

        lblNewQuiz.Center()();

        txtBoxEmailRegister.Center()();
        txtBoxEmailRegister.Left -= 55;

        btnRegister.Center()();
        btnRegister.Left += 90;


    }
}
