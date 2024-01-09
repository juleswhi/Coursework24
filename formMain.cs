namespace FamousLakesQuiz;

public partial class formMain : Form
{
    private readonly Font _font = new(FontFamily.GenericMonospace, emSize: 20);
    public formMain()
    {
        InitializeComponent();
        Label _labelTitle = new()
        {
            Text = "Famous Lakes Quiz!",
            Location = new((int)Left + (0.5 * Width) + (0.5 * TextRenderer.MeasureText("Famous Lakes Quiz!", _font).Width)), 20)
        };

    }
}
