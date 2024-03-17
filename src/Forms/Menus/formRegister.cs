using ChessMasterQuiz.Misc;
using static ChessMasterQuiz.Misc.ValidationType;

namespace ChessMasterQuiz;
public partial class formRegister : Form, IContext
{
    private readonly Dictionary<ValidationType, ProgressBar> ValidationToBarMap = new();
    private readonly Dictionary<ValidationType, bool> ValidationToBoolMap = new()
    {
        { USERNAME, false },
        { PASSWORD, false },
        { DISPLAY, false },
        { GENDER, false },
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
            { GENDER, pBarGender }
        };

        pBoxLogo.Image = GetLogo();
        pBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        progressPassword.Maximum = 100;
        Resize += FormRegister_Resize;
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
                    ValidationToBarMap[vt].Value = val ? (int)percentage : 0;
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
    private void FormRegister_Resize(object? sender, EventArgs e)
    {
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Dictionary<ValidationType, string> ValidationToTextBox = new()
        {
            // Fields
            { USERNAME,  txtBoxEmail.Text },
            { PASSWORD, txtBoxPassword.Text },
            { GENDER, txtBoxGender.Text },
            { DISPLAY, txtBoxDisplayName.Text } ,
            { DOB, txtBoxDob.Text }
        };

        var enumValues = Enum.GetValues(typeof(ValidationType)).Cast<ValidationType>();

        foreach (var val in enumValues.Where(x => x != ValidationType.EMAIL))
        {
            if (!ValidationToTextBox[val].Validate(val).Item1)
            {
                return;
            }
        }

        var user = new UserRepresentation.User(
            name: ValidationToTextBox[DISPLAY],
            password: ValidationToTextBox[PASSWORD]
            )
        {
            Gender = ValidationToTextBox[GENDER],
            DOB = DateTime.Parse(ValidationToTextBox[DOB]),
            Username = ValidationToTextBox[USERNAME]
        };

        Users.Add(user);

        WriteUser(user);

        ActivateForm<formMenu>((user, USER));
    }

    private void progressPassword_Click(object sender, EventArgs e)
    {

    }

    private void txtBoxEmail_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        ActivateForm<formLogin>();
    }

    private void txtBoxGender_TextChanged(object sender, EventArgs e)
    {

    }
}
