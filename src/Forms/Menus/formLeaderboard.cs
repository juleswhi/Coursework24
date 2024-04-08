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
        // Grab panels and order based on specific tags
        List<Panel> panels = new();
        panels.AddRange(Controls.OfType<Panel>().First().Controls.OfType<Panel>());
        _ = panels.OrderBy(x => -int.Parse((string)x.Tag!));

        // Sort users aswell
        List<User> users = SortbyType(Users, sortType).Take(panels.Count).ToList();
        users.Reverse();

        // Match up user and panel and display on label 
        for (int i = 0; i < users.Count; i++)
        {
            Label? name = panels[panels.Count - i - 1].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "username");
            Label? elo = panels[panels.Count - i - 1].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "elo");
            Label? accuracy = panels[panels.Count - i - 1].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "accuracy");
            Label? high = panels[panels.Count - i - 1].Controls.OfType<Label>()
                .FirstOrDefault(x => (string?)x.Tag == "high");

            string username = users[i].Username!;
            name!.Text = username;
            // redirect user to the user profile on click
            name.Click += (s, e) =>
            {
                ActivateForm<formUserProfile>((Users.First(x => x.Username == username), USER));
            };
            elo!.Text = $"{users[i].Elo.Rating}";
            accuracy!.Text = $"{users[i].Accuracy}";
            high!.Text = $"{users[i].HighScore}";
        }
    }

    private List<User> SortbyType(List<User> users, SortType type)
    {
        // sort by appropriate type
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

    // Visual reference to user of what column is sorted on
    private void UpdateSortColumn(Label? label)
    {
        if (label is null)
        {
            return;
        }

        foreach (Label l in Controls.OfType<Label>())
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
