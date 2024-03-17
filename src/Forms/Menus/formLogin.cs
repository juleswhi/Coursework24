using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz;

public partial class formLogin : Form, IContext
{
    public formLogin()
    {
        InitializeComponent();

        pBoxLogo.Image = GeneralResources.ChessMaster_Alpha;
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

        Resize += onResize;
        btnRegister.Click += (s, e) =>
        {
            ActivateForm<formRegister>();
        };
    }

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
        ActivateForm<formMenu>((foundUser, USER));
    }

    private void formLogin_Load(object sender, EventArgs e)
    {

    }

    public void UseContext(IEnumerable<DCT> context)
    {
    }

    private void txtBoxEmail_TextChanged(object sender, EventArgs e)
    {

    }
}
