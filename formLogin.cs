using static ChessMasterQuiz.ContextTagType;
using static ChessMasterQuiz.Helpers.UserHelper;
using static ChessMasterQuiz.Helpers.ControlHelper;
using static ChessMasterQuiz.Helpers.FormatDirection;
using System.Diagnostics;
using ChessMasterQuiz.Helpers;

namespace ChessMasterQuiz;

public partial class formLogin : Form, IContext
{
    private List<DataContextTag> _context = new();
    public formLogin()
    {
        InitializeComponent();

        Resize += onResize;
        btnRegister.Click += (s, e) =>
        {
            ActivateForm<formRegister>(new DataContextTag(txtBoxEmailRegister.Text, EMAIL));
        };
    }

    Control.ControlCollection IContext._controls => Controls;
    private void onResize(object? sender, EventArgs e)
    {
        lblLogin.Center(X);
        txtBoxEmail.Center(X);
        txtBoxPassword.Center(X);
        btnLogin.Center(X);

        lblNewQuiz.Center(X);

        txtBoxEmailRegister.Center(X);
        txtBoxEmailRegister.Left -= 55;

        btnRegister.Center(X);
        btnRegister.Left += 90;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string emailText = txtBoxEmail.Text;
        string passwordText = txtBoxPassword.Text;

        var foundUser = Users.FirstOrDefault(x => x.Email?.Address == emailText);
        if (foundUser is null)
        {
            Debug.Print("Couldn't Find the entered user");
            return;
        }

        if(!passwordText.VerifyPassword(foundUser!))
        {
            Debug.Print("Wrong Password");
            return;
        }


        foundUser.Login();
        ControlHelper.ActivateForm<formMenu>();
    }
}
