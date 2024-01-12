namespace FamousLakesQuiz;

public partial class formRegister : Form
{
    public formRegister()
    {
        InitializeComponent();
        Resize += FormRegister_Resize;
        Controls.OfType<TextBox>().ToList().CreateEquidistantIntervals(10);
    }

    public formRegister(IEnumerable<DataContextTag> context) : this()
    {
        foreach (var c in Controls.OfType<TextBox>())
        {
            foreach (var dct in context)
            {
                if ((string)dct.data == "") continue;
                if (c.PlaceholderText.ToLower() != dct.tag) continue;
                c.Text = (string)dct.data;
            }
        }
    }

    private void FormRegister_Resize(object? sender, EventArgs e)
    {
        foreach (var c in Controls.OfType<TextBox>())
        {
            c.Center()();
        }
        btnRegister.Center()();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        List<(string, RegBoxType)> deets = new()
        {
            // Fields
            (txtBoxEmail.Text, RegBoxType.EMAIL),
            (txtBoxPassword.Text, RegBoxType.PASSWORD),
            (txtBoxGender.Text, RegBoxType.GENDER),
            (txtBoxDisplayName.Text, RegBoxType.DISPLAY),
            (txtBoxDob.Text, RegBoxType.DOB)
        };

        // Encrypt

    }
    private enum RegBoxType
    {
        EMAIL,
        PASSWORD,
        DISPLAY,
        GENDER,
        DOB
    }
}
