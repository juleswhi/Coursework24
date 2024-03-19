namespace ChessMasterQuiz;

public partial class formLogin : Form
{
    public formLogin()
    {
        InitializeComponent();
        lblIncorrectDetails.Hide();

        // Fetch random logo image 
        pBoxLogo.Image = GetLogo();
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

        btnRegister.Click += (s, e) =>
            ActivateForm<formRegister>();
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
            lblIncorrectDetails.Show();
            return;
        }

        foundUser.Login();
        // Pass the user as context through to formMenu
        ActivateForm<formMenu>((foundUser, USER));
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
        // Shut down all threads aswell?
    }
}
