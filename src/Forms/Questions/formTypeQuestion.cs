namespace ChessMasterQuiz.Forms.Questions;

public partial class formTypeQuestion : Form, IContext
{
    public formTypeQuestion()
    {
        InitializeComponent();

        var board = new Board();

        board.Location = new Point(20, 20);

        Controls.Add(board);
    }

    public Action<bool, int> OnAnswered { get; set; } = EmptyActionGeneric<bool, int>();

    public void UseContext(IEnumerable<DCT> context)
    {
    }
}
