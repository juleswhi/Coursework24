using static FamousLakesQuiz.ValidationType;
using static FamousLakesQuiz.Helper;
using System.Net.Mail;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FamousLakesQuiz;
public partial class formRegister : Form, IContext
{
    public formRegister()
    {
        InitializeComponent();
        Resize += FormRegister_Resize;
        foreach (var control in Controls.OfType<TextBox>())
        {
            control.TextChanged += (s, _) =>
            {
                var sender = (s as TextBox)!;
                ValidationType vt = (ValidationType)Enum.Parse(typeof(ValidationType), sender.Tag!.ToString()!.ToUpper());
                Debug.Print(vt.ToString());
                control.RedIfWrong(sender.Text.Validate(vt));
            };
        }
    }

    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        foreach (var dct in context)
        {
            if (dct.tag == "email")
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
        btnRegister.Center(X);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Dictionary<ValidationType, string> ValidationToTextBox = new()
        {
            // Fields
            {EMAIL,  txtBoxEmail.Text },
            {PASSWORD, txtBoxPassword.Text },
            {GENDER, txtBoxGender.Text },
            {DISPLAY, txtBoxDisplayName.Text } ,
            {DOB, txtBoxDob.Text }
        };

        var enumValues = Enum.GetValues(typeof(ValidationType)).Cast<ValidationType>();

        foreach(var val in enumValues)
        {
            if (ValidationToTextBox[val].Validate(val))
            {
                return;
            }
        }

        new User(
            name: ValidationToTextBox[DISPLAY],
            password: ValidationToTextBox[PASSWORD]
            ); 
    }
}
