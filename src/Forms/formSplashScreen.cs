namespace ChessMasterQuiz.Forms;

public partial class formSplashScreen : Form
{
    private float progress = 0;
    public formSplashScreen()
    {
        InitializeComponent();

        // Set form to double buffered
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        // Set panel to double bufferd
        typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
        | BindingFlags.Instance | BindingFlags.NonPublic, null,
        pnlProgressBar, new object[] { true });

        pnlProgressBar.Paint += (s, e) =>
        {
            e.Graphics.FillRectangle(Brushes.LightGreen, new Rectangle(0, 0, (int)(pnlProgressBar.Width * progress), pnlProgressBar.Height));
        };

        System.Timers.Timer timer = new(0.05);

        timer.Elapsed += (s, e) =>
        {
            progress += 0.005f;
            if (progress >= 1.0f)
            {
                timer.Stop();
            }

            pnlProgressBar.Invalidate();
        };

        timer.Start();

        WaitForTimer();

        Board board = new();
        board.Location = new Point((int)((0.5 * Width) - (0.5 * board.Width)), Location.Y);
        Controls.Add(board);
        board.DisplayGame(ChessHelper.GetScholarsMate(), 500);
    }

    private async void WaitForTimer()
    {
        await Task.Delay(3250);
        ActivateForm<formLogin>();
    }
}
