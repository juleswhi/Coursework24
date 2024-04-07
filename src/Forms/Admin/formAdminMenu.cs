namespace ChessMasterQuiz.Forms.Admin;

public partial class formAdminMenu : Form
{
    private AdminConfiguration? _config = new();
    public formAdminMenu()
    {
        InitializeComponent();

        lblUserNotExist.Hide();
        lblPromoteYourself.Hide();

        txtBoxPromote.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtBoxPromote.AutoCompleteSource = AutoCompleteSource.CustomSource;

        txtBoxPromote.AutoCompleteCustomSource.AddRange(Users.Select(x => x.Username).ToArray());

        List<CheckBox> checkBoxes = Controls.OfType<CheckBox>().ToList();

        _config = GetAdminConfig();
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
        ActivateForm<formViewQuestions>();
    }

    private void btnPromote_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBoxPromote.Text))
            return;

        string username = txtBoxPromote.Text;

        User? user = Users.FirstOrDefault(x => x.Username == username);

        if (user is null)
        {
            lblUserNotExist.Show();
            lblPromoteYourself.Hide();
            return;
        }

        if (user.Username == ActiveUser?.Username)
        {
            lblUserNotExist.Hide();
            lblPromoteYourself.Show();
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

        if (user.Username == ActiveUser?.Username)
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

    private void btnStrong_Click(object sender, EventArgs e)
    {
        if (_config is AdminConfiguration c)
        {
            c.PasswordRequirementLevel = STRONG;
            c.Write();
        }
    }

    private void btnMedium_Click(object sender, EventArgs e)
    {
        if (_config is AdminConfiguration c)
        {
            c.PasswordRequirementLevel = MEDIUM;
            c.Write();
        }
    }

    private void btnWeak_Click(object sender, EventArgs e)
    {
        if (_config is AdminConfiguration c)
        {
            c.PasswordRequirementLevel = WEAK;
            c.Write();
        }
    }
}
