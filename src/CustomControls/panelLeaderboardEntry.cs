﻿namespace ChessMasterQuiz.CustomControls;

internal class panelLeaderboardEntry : Panel
{
    public User? user = null;
    public panelLeaderboardEntry(User u, int x, int y, int width, int height, int index) : base()
    {
        Size = new Size(width, height / 5);
        user = u;
        int panelWidth = width / 5;
        int panelHeight = height / 5;

        List<Panel> panels = new();
        for (int i = 0; i < 5; i++)
        {
            Panel panel = new()
            {
                Size = new(panelWidth, 50),
                Location = new(x + (panelWidth * i), y + (panelHeight * index))
            };

            panels.Add(panel);
        }
        panels.ForEach(panel =>
        {
            Controls.Add(panel);
            panel.Controls.Add(new Label());
            panel.Controls[0].Font = new Font(FontFamily.GenericMonospace, 15);
            panel.Controls[0].Dock = DockStyle.Fill;
            (panel.Controls[0] as Label)!.TextAlign = ContentAlignment.MiddleCenter;
            (panel.Controls[0] as Label)!.AutoSize = false;
        });

        panels[0].Controls[0].Text = $"{user.Username}";
        panels[1].Controls[0].Text = $"{user.Elo.Rating}";
        panels[2].Controls[0].Text = $"{user.Accuracy}";
        panels[3].Controls[0].Text = $"{user.HighScore}";
        panels[4].Controls[0].Text = $"{user.QuizesCompleted}";
    }

}
