using System.Net.Mail;
using static ChessMasterQuiz.Misc.ValidationType;

namespace ChessMasterQuiz;
public partial class formRegister : Form, IContext
{
    private readonly Dictionary<ValidationType, ProgressBar> ValidationToBarMap = new();
    private readonly Dictionary<ValidationType, bool> ValidationToBoolMap = new()
    {
        { USERNAME, false },
        { PASSWORD, false },
        { PASSWORD_CONFIRM, false },
        { ValidationType.EMAIL, false },
        { DOB, false }
    };

    public formRegister()
    {
        InitializeComponent();

        btnRegister.Enabled = false;
        ValidationToBarMap = new()
        {
            { DISPLAY, pBarDisplayName },
            { USERNAME, pBarUsername },
            { DOB, pBarDob },
            { ValidationType.EMAIL, pBarGender },
            { PASSWORD_CONFIRM, pBarDisplayName }
        };

        pBoxLogo.Image = GetLogo();
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        progressPassword.Maximum = 100;
        TextBox? passwordBox = Controls.OfType<TextBox>().FirstOrDefault(x => (x.Tag as string) == "password");
        foreach (var control in Controls.OfType<TextBox>())
        {
            control.TextChanged += (s, _) =>
            {
                var sender = (s as TextBox)!;
                ValidationType vt = (ValidationType)Enum.Parse(typeof(ValidationType), sender.Tag!.ToString()!.ToUpper());
                (var val, var percentage) = sender.Text.Validate(vt);
                if (vt is PASSWORD)
                {
                    progressPassword.Value = Math.Min(Math.Max(0, (int)percentage), 100);
                }
                else
                {
                    if (vt is PASSWORD_CONFIRM && passwordBox?.Text == sender.Text)
                    {
                        pBarDisplayName.Value = 100;
                        val = true;
                    }
                    else ValidationToBarMap[vt].Value = val ? (int)percentage : 0;
                }

                ValidationToBoolMap[vt] = val;

                if (ValidationToBoolMap.All(x => x.Value == true))
                {
                    btnRegister.Enabled = true;
                }
                else
                {
                    btnRegister.Enabled = false;
                }
            };
        }
    }

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

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Dictionary<ValidationType, string> ValidationToTextBox = new()
        {
            // Fields
            { USERNAME,  txtBoxEmail.Text },
            { PASSWORD, txtBoxPassword.Text },
            { ValidationType.EMAIL, txtBoxDisplayName.Text } ,
            { DOB, txtBoxDob.Text }
        };

        var enumValues = Enum.GetValues(typeof(ValidationType)).Cast<ValidationType>();

        foreach (var val in enumValues.Where(ValidationToTextBox.ContainsKey))
        {
            if (!ValidationToBoolMap[val])
            {
                return;
            }
        }

        var _ = MailAddress.TryCreate(ValidationToTextBox[ValidationType.EMAIL], out var addy);

        var user = new User(
            name: ValidationToTextBox[USERNAME],
            password: ValidationToTextBox[PASSWORD]
            )
        {
            Email = addy,
            DOB = DateTime.Parse(ValidationToTextBox[DOB]),
            Username = ValidationToTextBox[USERNAME]
        };

        Users.Add(user);

        WriteUser(user);

        ActivateForm<formLogin>();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        ActivateForm<formLogin>();
    }

}
