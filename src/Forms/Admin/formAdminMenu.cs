using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Forms.Admin;

public partial class formAdminMenu : Form
{
    public formAdminMenu()
    {
        InitializeComponent();

        txtBoxPromote.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtBoxPromote.AutoCompleteSource = AutoCompleteSource.CustomSource;

        txtBoxPromote.AutoCompleteCustomSource.AddRange(Users.Select(x => x.Username).ToArray());

        foreach (CheckBox checkBox in Controls.OfType<CheckBox>())
        {
            checkBox.CheckedChanged += (s, e) =>
            {
                foreach (CheckBox cbox in Controls.OfType<CheckBox>())
                {
                    cbox.Checked = false;
                }

                var config = GetAdminConfig();
                if (config is AdminConfiguration c)
                {
                    c.PasswordRequirementLevel = (string?)checkBox.Tag switch
                    {
                        "Strong" => STRONG,
                        "Medium" => MEDIUM,
                        _ => WEAK
                    };

                    c.Write();
                }

                checkBox.Checked = true;
            };
        }
    }

    private void btnCreatePuzzles_Click(object sender, EventArgs e)
    {
        ActivateForm<formCreatePuzzle>();
    }

    private void btnCreateQuestions_Click(object sender, EventArgs e)
    {
        ActivateForm<formAddQuestion>();
    }

    private void btnViewPuzzles_Click(object sender, EventArgs e)
    {
        ActivateForm<formViewPuzzles>();
    }

    private void btnViewQuestions_Click(object sender, EventArgs e)
    {
        // View questions
    }

    private void btnPromote_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBoxPromote.Text))
            return;

        string username = txtBoxPromote.Text;

        User? user = Users.FirstOrDefault(x => x.Username == username);

        if (user is null)
        {
            return;
        }

        if(user.Username == ActiveUser?.Username)
        {
            MessageBox.Show($"You cannot promote yourself");
            return;
        }

        user.Type = UserType.ADMIN;

        UpdateUser(user);

        txtBoxPromote.Text = "";
    }

    private void btnDemote_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBoxPromote.Text))
            return;

        string username = txtBoxPromote.Text;

        User? user = Users.FirstOrDefault(x => x.Username == username);

        if (user is null)
        {
            return;
        }

        if(user.Username == ActiveUser?.Username)
        {
            MessageBox.Show($"You cannot demote yourself");
            return;
        }

        user.Type = UserType.USER;

        UpdateUser(user);

        txtBoxPromote.Text = "";
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }
}
