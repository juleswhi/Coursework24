using static ChessMasterQuiz.Helpers.ControlHelper;
using static ChessMasterQuiz.Helpers.FormatDirection;
using static ChessMasterQuiz.ValidationType;
using Newtonsoft.Json;
using static ChessMasterQuiz.Helper;
using System.Net.Mail;
using ChessMasterQuiz.QuestionDir;
using ChessMasterObjectNotation;
using static ChessMasterObjectNotation.Difficulty;
using static ChessMasterObjectNotation.QuestionType;
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
            ActivateForm<formRegister>(new DataContextTag(txtBoxEmailRegister.Text, "email"));
        };
    }

    private void ActivateForm<T>(DataContextTag dataContextTag)
    {
        throw new NotImplementedException();
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
        // Readin Users

        string emailText = txtBoxEmail.Text;
        string passwordText = txtBoxPassword.Text;

        if(emailText == "root" && passwordText == "root")
        {
            ControlHelper.ActivateForm<formMenu>();
        }

        var u = new User(
            "James",
            "password",
            false);

        u.Login();

        // var foundUser = Users.Where(x => x.Email?.Address == mailAddr.Address && passwordText.VerifyPassword(x));
    }
}
