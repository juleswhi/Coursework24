namespace ChessMasterQuiz.Forms.Menus;

public partial class formLeaderboard : Form
{
    public formLeaderboard()
    {
        InitializeComponent();

        List<Panel> panels = new();
        panels.AddRange(Controls.OfType<Panel>().First().Controls.OfType<Panel>());
        panels.OrderBy(x => int.Parse((string)x.Tag!));

        Span<User> users = SortbyType(Users, SortType.ELO).Take(panels.Count).ToArray().AsSpan();

        for (int i = 0; i < users.Length; i++)
        {
            Label? name = panels[i].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "username");
            Label? elo = panels[i].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "elo");
            Label? accuracy = panels[i].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "accuracy");
            Label? high = panels[i].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "high");

            name!.Text = $"{users[i].Username}";
            elo!.Text = $"{users[i].Elo.Rating}";
            accuracy!.Text = $"{users[i].Accuracy}";
            high!.Text = $"{users[i].HighScore}";
        }
    }

    private List<User> SortbyType(List<User> users, SortType type)
    {
        List<User> sorted = users.OrderBy(x => type switch
        {
            SortType.OVERRALL => x.Elo.Rating,
            SortType.ELO => x.Elo.Rating,
            SortType.HIGHSCORE => x.HighScore,
            SortType.GAMES => x.QuizesCompleted,
            _ => x.Elo.Rating
        }).ToList();

        return sorted;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }

    private void lblElo_Click(object sender, EventArgs e)
    {

    }

    private void lblAccuracy_Click(object sender, EventArgs e)
    {

    }

    private void lblHighScore_Click(object sender, EventArgs e)
    {

    }

    private void pnlUserOne_Paint(object sender, PaintEventArgs e)
    {

    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private enum SortType
    {
        OVERRALL,
        ELO,
        HIGHSCORE,
        GAMES
    }
}
