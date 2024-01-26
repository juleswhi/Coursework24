using static FamousLakesQuiz.ValidationType;
using Newtonsoft.Json;
using static FamousLakesQuiz.Helper;
using System.Net.Mail;
using FamousLakesQuiz.QuestionDir;
using QonSerializer;
using static QonSerializer.Difficulty;
using static QonSerializer.QuestionType;


namespace FamousLakesQuiz;

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

        TextQuestion q = new()
        {
            Q = "Q1",
            A = new Answer(new() 
          {
              "One",
              "Two",
              "Three",
              "Four"
          },
          2),
            Difficulty = MEDIUM
        };

        ActivateForm<formTextQuestion>(new DataContextTag(
            q,
            "question"
            ),
            new DataContextTag(
                "1",
                "number" 
                ));
        return;
        string emailText = txtBoxEmail.Text;
        string passwordText = txtBoxPassword.Text;

        if(string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(passwordText))
        {
            return;
        }

        if(!emailText.Validate(EMAIL))
        {
            return;
        }

        if (!MailAddress.TryCreate(emailText, out MailAddress mailAddr))
        {
            return;
        }

        var foundUser = Users.Where(x => x.Email?.Address == mailAddr.Address && passwordText.VerifyPassword(x));

        if(foundUser.Any())
        {
            foundUser.First().Login();
            lblLogin.Text = "logged in";
        }
    }
}
