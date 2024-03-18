using ChessMasterQuiz.Chess;
using static Chess.ChessHelper;

namespace Chess.BoardRepresentation;

public class Board : Panel
{
    public Piece? this[char file, int rank] =>
        Pieces.FirstOrDefault(x => x.Location! == Notation.From(file, rank));
    public Piece? this[SAN location] =>
        Pieces.FirstOrDefault(x => x.Location!.ToString() == location.GetNotation());
    public Piece? this[string location] =>
        Pieces.FirstOrDefault(x => x.Location!.Equals(location));

    public Piece? this[Notation location] =>
        Pieces.FirstOrDefault(x => x.Location! == location);

    public Action<Square?> BoardClick = EmptyActionGeneric<Square?>();

    private static readonly Size _defaultBoardSize = new(400, 400);
    private int _squareWidth => this.Size.Width / 8;

    public Square? SelectedSquare = null;

    public List<Square> Squares = new();
    public List<Piece> Pieces = new();
    public Board(Size? size = null) : base()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        MoveHelper.CurrentBoard = this;
        base.BackColor = Color.Gray;
        size ??= _defaultBoardSize;
        Size = (Size)size;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 8; j >= 0; j--)
            {
                Squares.Add(
                    // Obfuscation so you can't ever understand this
                    // Documentation can be found in hell
                    new Square(
                        (i + j) % 2 == 0
                            ? Black
                            : White,
                        new Point(i * 50, 350 - (j * 50)),
                        ((char)(i + 97), j + 1)
                            ));
            }
        }

        Squares.RemoveAll(x => x.BoardLocation.Item2 == 9);

        // Generate both the white and black pieces
        Pieces = PopulatePieces();

        Paint += Draw;
        Click += (object? s, EventArgs e) =>
        {
            var pos = PointToClient(MousePosition);

            Point roundedPoint = new(

                (int)Math.Floor(pos.X / 50m) * 50,
                (int)Math.Floor(pos.Y / 50m) * 50
                );

            foreach (var square in Squares)
            {
                if (square.Location == roundedPoint)
                {
                    SelectedSquare = square;
                    BoardClick(SelectedSquare);
                }
            }

            Invalidate();
        };

        Invalidate();
    }


    private void Draw(object? sender, PaintEventArgs e)
    {
        e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        foreach (var square in Squares)
        {
            e.Graphics.FillRectangle(
                square.Colour == White ? Brushes.LightGray : Brushes.DarkGray,
                new Rectangle(square.Location, new(50, 50))
            );


            if (SelectedSquare is Square key)
            {
                if (key == square)
                {
                    e.Graphics.FillRectangle(
                        square.Colour == White ? Brushes.LightGreen : Brushes.DarkGreen,
                    new Rectangle(square.Location, new(50, 50))
                    );
                }
            }


            foreach (var piece in Pieces)
            {
                if (MoveHelper.SquareIsNotation(Notation.From(square.BoardLocation), piece.Location))
                {
                    /*
                    e.Graphics.FillRectangle(
                        Brushes.Green,
                        new Rectangle(square.Location, new(50, 50))
                        );
                    */

                    // e.Graphics.DrawString($"{piece.Type}", new Font(FontFamily.GenericMonospace, 10), Brushes.Green, square.Location);
                    var image = piece.GetImage();
                    e.Graphics.DrawImage(image, image.GetCenter(square.Location, new(_squareWidth, _squareWidth)));
                }
            }


        }
    }

    public void StopGame()
    {
        _continueGame = false;
    }

    private bool _continueGame = true;

    public void DisplayGame(PGN pgn, int PlyPause = 1000, Action? onGameOver = null)
    {
        Thread gameThread = new(() =>
        {
            _continueGame = true;
            foreach (var (white, black) in pgn.Moves)
            {
                if (white.NullMove) break;
                this[white.InitialSquare]?.Move(white);
                Thread.Sleep(PlyPause);
                if (black is null)
                {
                    break;
                }
                if (black.NullMove) break;
                this[black.InitialSquare]?.Move(black);
                Thread.Sleep(PlyPause);
                if (!_continueGame)
                {
                    break;
                }

                if(onGameOver is Action action)
                {
                    action();
                }
            }
        });
        gameThread.Start();

    }
}
