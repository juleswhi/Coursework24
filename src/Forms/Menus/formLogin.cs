using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz;

public partial class formLogin : Form, IContext
{
    public formLogin()
    {
        InitializeComponent();
        lblIncorrectDetails.Hide();

        pBoxLogo.Image = GetLogo();
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

        btnRegister.Click += (s, e) =>
        {
            ActivateForm<formRegister>();
        };
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string usernameText = txtBoxEmail.Text;
        string passwordText = txtBoxPassword.Text;

        var foundUser = Users.FirstOrDefault(x => x.Username == usernameText);
        if (foundUser is null)
        {
            lblIncorrectDetails.Show();
            return;
        }

        if (!passwordText.VerifyPassword(foundUser!))
        {
            return;
        }

        foundUser.Login();
        ActivateForm<formMenu>((foundUser, USER));
    }

    public void UseContext(IEnumerable<DCT> context)
    {}

    private void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
        // Shut down all threads aswell?
    }
}
