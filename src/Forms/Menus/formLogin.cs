using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz;

public partial class formLogin : Form, IContext
{
    private List<DataContextTag> _context = new();
    public formLogin()
    {
        InitializeComponent();

        pBoxLogo.Image = GeneralResources.ChessMasterLogo;
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

        Resize += onResize;
        btnRegister.Click += (s, e) =>
        {
            ActivateForm<formRegister>();
        };
    }

    Control.ControlCollection IContext._controls => Controls;
    private void onResize(object? sender, EventArgs e)
    {
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string usernameText = txtBoxEmail.Text;
        string passwordText = txtBoxPassword.Text;

        var foundUser = Users.FirstOrDefault(x => x.Username == usernameText);
        if (foundUser is null)
        {
            return;
        }

        if (!passwordText.VerifyPassword(foundUser!))
        {
            return;
        }

        foundUser.Login();
        ActivateForm<formMenu>(new DataContextTag(foundUser, USER));
    }

    private void formLogin_Load(object sender, EventArgs e)
    {

    }
}
