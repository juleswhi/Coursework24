using ChessMasterQuiz.Forms;

namespace ChessMasterQuiz;

public partial class formMain : Form
{
    public static Form? ChildForm { get; set; } = null;
    public static Func<Panel>? GetPanelHolder { get; set; } = null;

    public formMain()
    {
        InitializeComponent();
        GetPanelHolder = () => panelHolder;
        Text = "Chess Master Quiz";

        Users.ForEach(x => x.Logout());

        ActivateForm<formSplashScreen>();
    }
}
