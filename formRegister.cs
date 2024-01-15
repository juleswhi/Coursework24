namespace FamousLakesQuiz;

public partial class formRegister : Form
{
    public formRegister()
    {
        InitializeComponent();
        Resize += FormRegister_Resize;
    }

    private void UseContext(IEnumerable<object> context) 
    {
        var dcts = context.ToDCT();

        foreach(var dct in dcts)
        {
            var control = Controls.OfType<TextBox>().FindTag(dct.tag);
            if (control is null) continue;

            (control as TextBox)!.PlaceholderText = (string)dct.data;
        }

    }

    private void FormRegister_Resize(object? sender, EventArgs e)
    {
        foreach (var c in Controls.OfType<TextBox>())
        {
            c.Center()(X);
        }
        btnRegister.Center()(X);
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
