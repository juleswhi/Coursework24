namespace ChessMasterQuiz.Forms.Menus;

public partial class formLeaderboard : Form
{
    public formLeaderboard()
    {
        InitializeComponent();

        DisplayInformation();
        UpdateSortColumn(lblElo);
    }

    private void DisplayInformation(SortType sortType = SortType.ELO)
    {
        List<Panel> panels = new();
        panels.AddRange(Controls.OfType<Panel>().First().Controls.OfType<Panel>());
        panels.OrderBy(x => int.Parse((string)x.Tag!));

        Span<User> users = SortbyType(Users, sortType).Take(panels.Count).ToArray().AsSpan();

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
            SortType.ELO => x.Elo.Rating,
            SortType.HIGHSCORE => x.HighScore,
            SortType.ACCURACY => x.Accuracy,
            _ => x.Elo.Rating
        }).ToList();

        return sorted;
    }


    private void lblElo_Click(object sender, EventArgs e)
    {
        DisplayInformation(SortType.ELO);
        UpdateSortColumn(sender as Label);
    }

    private void lblAccuracy_Click(object sender, EventArgs e)
    {
        DisplayInformation(SortType.ACCURACY);
        UpdateSortColumn(sender as Label);
    }

    private void lblHighScore_Click(object sender, EventArgs e)
    {
        DisplayInformation(SortType.HIGHSCORE);
        UpdateSortColumn(sender as Label);
    }

    private void btnMainMenu_Click(object sender, EventArgs e)
    {
        ActivateForm<formMenu>();
    }

    private void UpdateSortColumn(Label? label)
    {
        if (label is null) return;
        foreach(Label l in Controls.OfType<Label>())
        {
            l.Text = l.Text.Replace("*", "");
        }

        label.Text += "*";
    }

    private enum SortType
    {
        ELO,
        HIGHSCORE,
        GAMES,
        ACCURACY
    }
}
