using ChessMasterQuiz.UserRepresentation;
using static ChessMasterQuiz.Misc.ContextTagType;
using static ChessMasterQuiz.Helpers.ControlHelper;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms;

public partial class formUserProfile : Form, IContext
{
    public formUserProfile()
    {
        InitializeComponent();
    }

    Control.ControlCollection IContext._controls => Controls;

    public void UseContext(IEnumerable<DataContextTag> context)
    {
        User? user = context.FirstOrDefault(x => x.tag! == USER)!.data! as User;
        if (user is null)
        {
            return;
        }

        lblUsername.Text = user.Name;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void pBoxProfileImage_Click(object sender, EventArgs e)
    {

    }

    private void lblMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }
}
