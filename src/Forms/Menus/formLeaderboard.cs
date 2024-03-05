using ChessMasterQuiz.CustomControls;

namespace ChessMasterQuiz.Forms.Menus;

public partial class formLeaderboard : Form
{
    public formLeaderboard()
    {
        InitializeComponent();
        flpEntries.FlowDirection = FlowDirection.TopDown;

        int index = 1;
        foreach(var user in SortbyType(Users, SortType.OVERRALL).Take(5))
        {
            flpEntries.Controls.Add(new panelLeaderboardEntry(user!, index));
            index ++;
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

    private enum SortType
    {
        OVERRALL,
        ELO,
        HIGHSCORE,
        GAMES
    }
}
