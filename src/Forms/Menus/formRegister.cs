using static ChessMasterQuiz.Misc.ContextTagType;
using static ChessMasterQuiz.Helpers.ControlHelper;
using static ChessMasterQuiz.Helpers.FormatDirection;
using static System.FormatException;
using static ChessMasterQuiz.Misc.ValidationType;
using static ChessMasterQuiz.Helper;
using System.Net.Mail;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz;
public partial class formRegister : Form, IContext
{
    public formRegister()
    {
        InitializeComponent();
        progressPassword.Maximum = 100;
        Resize += FormRegister_Resize;
        foreach (var control in Controls.OfType<TextBox>())
        {
            control.TextChanged += (s, _) =>
            {
                var sender = (s as TextBox)!;
                ValidationType vt = (ValidationType)Enum.Parse(typeof(ValidationType), sender.Tag!.ToString()!.ToUpper());
                (var val, var percentage) = sender.Text.Validate(vt);
                if(vt is PASSWORD)
                {
                    progressPassword.Value = Math.Min(Math.Max(0, (int)percentage), 100);
                }
                else control.RedIfWrong(val);
            };
        }
    }

    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        foreach (var dct in context)
        {
            if (dct.tag == ContextTagType.EMAIL)
            {
                txtBoxEmail.Text = (string)dct.data;
            }
        }
    }
    private void FormRegister_Resize(object? sender, EventArgs e)
    {
        foreach (var c in Controls.OfType<TextBox>())
        {
            c.Center(X);
        }
        progressPassword.Center(X);
        btnRegister.Center(X);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Dictionary<ValidationType, string> ValidationToTextBox = new()
        {
            // Fields
            {ValidationType.EMAIL,  txtBoxEmail.Text },
            {PASSWORD, txtBoxPassword.Text },
            {GENDER, txtBoxGender.Text },
            {DISPLAY, txtBoxDisplayName.Text } ,
            {DOB, txtBoxDob.Text }
        };

        var enumValues = Enum.GetValues(typeof(ValidationType)).Cast<ValidationType>();

        foreach (var val in enumValues)
        {
            if (ValidationToTextBox[val].Validate(val).Item1)
            {
                return;
            }
        }

        new User(
            name: ValidationToTextBox[DISPLAY],
            password: ValidationToTextBox[PASSWORD]
            );
    }

    private void progressPassword_Click(object sender, EventArgs e)
    {

    }
}
