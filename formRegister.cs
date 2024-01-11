namespace FamousLakesQuiz;

public partial class formRegister : Form
{
    public formRegister()
    {
        InitializeComponent();
        Resize += FormRegister_Resize;
    }

    public formRegister(IEnumerable<DataContextTag> context) : this()
    {
        foreach (var c in Controls.OfType<TextBox>())
        {
            foreach (var dct in context)
            {
                if ((string)dct.data == "") continue;
                if (c.PlaceholderText.ToLower() != dct.tag) continue;
                c.PlaceholderText = (string)dct.data;
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

}
