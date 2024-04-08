namespace ChessMasterQuiz.Forms.Admin;

public partial class formCreateTypeQuestion : Form
{
    private readonly List<Piece> pieces = new();
    private readonly Board? _board = new();

    private PieceType? SelectedPiece = null;
    private Colour? SelectedColour = null;
    private PictureBox? SelectedPBox = null;

    public formCreateTypeQuestion()
    {
        InitializeComponent();
        _board.Location = new Point(50, 20);
        _board.Pieces.Clear();

        _board.BoardClick += (Square? s) =>
        {
            if (SelectedPiece is null)
            {
                return;
            }

            if (SelectedColour is null)
            {
                return;
            }

            pieces.Add(new Piece((PieceType)SelectedPiece, From(s!.BoardLocation), (Colour)SelectedColour!));
            _board.Pieces = pieces;
            _board!.Invalidate();
        };

        foreach (PictureBox pbox in Controls.OfType<PictureBox>())
        {
            pbox.Click += (s, e) =>
            {
                if (SelectedPBox is not null)
                {
                    SelectedPBox.BorderStyle = BorderStyle.None;
                }
                SelectedPBox = pbox;
                SelectedPBox.BorderStyle = BorderStyle.FixedSingle;
            };
        }
        Controls.Add(_board);

    }

    private void btnCreatePuzzle_Click(object sender, EventArgs e)
    {
        string opening = txtBoxWinningMove.Text;

        TypeQuestion.ReadQuestions();

        if (TypeQuestion.Questions is null)
        {
            TypeQuestion.Questions = new();
        }

        TypeQuestion.Questions.Add(new TypeQuestion()
        {
            Question = $"What opening is this?",
            Answer = opening,
            Setup = pieces
        });

        TypeQuestion.WriteQuestions();

        foreach (TextBox tBox in Controls.OfType<TextBox>())
        {
            tBox.Text = "";
        }

        pieces.Clear();

        _board!.Invalidate();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        ActivateForm<formAdminMenu>();
    }

    private void pBoxWhitePawn_Click(object sender, EventArgs e)
    {
        SelectedPiece = PAWN;
        SelectedColour = White;
    }

    private void pBoxWhiteBishop_Click(object sender, EventArgs e)
    {
        SelectedPiece = BISHOP;
        SelectedColour = White;
    }

    private void pBoxWhiteQueen_Click(object sender, EventArgs e)
    {
        SelectedPiece = QUEEN;
        SelectedColour = White;
    }

    private void pBoxWhiteKnight_Click(object sender, EventArgs e)
    {
        SelectedPiece = KNIGHT;
        SelectedColour = White;
    }

    private void pBoxWhiteRook_Click(object sender, EventArgs e)
    {
        SelectedPiece = ROOK;
        SelectedColour = White;
    }

    private void pBoxWhiteKing_Click(object sender, EventArgs e)
    {
        SelectedPiece = KING;
        SelectedColour = White;
    }

    private void pBoxBlackPawn_Click(object sender, EventArgs e)
    {
        SelectedPiece = PAWN;
        SelectedColour = Black;
    }

    private void pBoxBlackKnight_Click(object sender, EventArgs e)
    {
        SelectedPiece = KNIGHT;
        SelectedColour = Black;
    }

    private void pBoxBlackBishop_Click(object sender, EventArgs e)
    {
        SelectedPiece = BISHOP;
        SelectedColour = Black;
    }

    private void pBoxBlackRook_Click(object sender, EventArgs e)
    {
        SelectedPiece = ROOK;
        SelectedColour = Black;
    }

    private void pBoxBlackQueen_Click(object sender, EventArgs e)
    {
        SelectedPiece = QUEEN;
        SelectedColour = Black;
    }

    private void pBoxBlackKing_Click(object sender, EventArgs e)
    {
        SelectedPiece = KING;
        SelectedColour = Black;
    }
}
