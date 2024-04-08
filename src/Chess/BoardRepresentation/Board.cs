using static Chess.ChessHelper;

namespace Chess.BoardRepresentation;

public class Board : Panel
{
    // These indexers allow for easy grabbing of a piece.  
    public Piece? this[string location] =>
        Pieces.FirstOrDefault(x => x.Location!.Equals(location));
    public Piece? this[Notation location] =>
        Pieces.FirstOrDefault(x => x.Location! == location);

    // This is a callback action which gets called when the board is clicked
    // The square which was clicked gets passed through
    public Action<Square?> BoardClick = EmptyActionGeneric<Square?>();

    // The normal board size 
    private static readonly Size _defaultBoardSize = new(400, 400);

    private int _squareWidth => Size.Width / 8;

    // Which square was last selected
    public Square? SelectedSquare = null;

    // All of the squares on the boarad
    public List<Square> Squares = new();

    // The pieces that should be displayed on the board
    public List<Piece> Pieces = new();

    public Board(Size? size = null) : base()
    {
        // Get rid of flickering in the board
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        MoveHelper.CurrentBoard = this;
        base.BackColor = Color.Gray;
        size ??= _defaultBoardSize;
        Size = (Size)size;

        // Loop through all squares coords on the board and create the representive Square object
        for (int i = 0; i < 8; i++)
        {
            for (int j = 8; j >= 0; j--)
            {
                Squares.Add(
                    new Square(
                        (i + j) % 2 == 0
                            ? Black
                            : White,
                        new Point(i * 50, 350 - (j * 50)),
                        ((char)(i + 97), j + 1)
                            ));
            }
        }

        // Generate the default pieces
        Pieces = PopulatePieces();

        Paint += Draw;
        Click += (object? s, EventArgs e) =>
        {
            var pos = PointToClient(MousePosition);

            // Gets the point of the square clostest to where the user clicked
            Point roundedPoint = new(
                (int)Math.Floor(pos.X / 50m) * 50,
                (int)Math.Floor(pos.Y / 50m) * 50
                );

            foreach (var square in Squares)
            {
                // Run the callback
                if (square.Location == roundedPoint)
                {
                    SelectedSquare = square;
                    BoardClick(SelectedSquare);
                }
            }

            // Display click on board
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
            // Draw all the black and white squares
            e.Graphics.FillRectangle(
                square.Colour == White ? Brushes.LightGray : Brushes.DarkGray,
                new Rectangle(square.Location, new(50, 50))
            );


            if (SelectedSquare is Square key)
            {
                // Draw green if square clicked
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
                if (MoveHelper.SquareIsNotation(From(square.BoardLocation), piece.Location))
                {
                    // Draw the piece!
                    var image = piece.GetImage();
                    e.Graphics.DrawImage(image, image.GetCenter(square.Location, new(_squareWidth, _squareWidth)));
                }
            }


        }
    }

    // Stop the external thread
    public void StopGame()
    {
        _continueGame = false;
    }

    private bool _continueGame = true;

    // Go through all the moves in the PGN and display at interval, 'PlyPause'
    public void DisplayGame(PGN pgn, int PlyPause = 1000, Action? onGameOver = null)
    {
        Thread gameThread = new(() =>
        {
            _continueGame = true;
            foreach (var (white, black) in pgn.Moves)
            {
                if (white.NullMove)
                {
                    break;
                }

                this[white.InitialSquare]?.Move(white);
                Thread.Sleep(PlyPause);
                if (black is null)
                {
                    break;
                }
                if (black.NullMove)
                {
                    break;
                }

                this[black.InitialSquare]?.Move(black);
                Thread.Sleep(PlyPause);
                if (!_continueGame)
                {
                    break;
                }

                if (onGameOver is Action action)
                {
                    action();
                }
            }
        });
        gameThread.Start();

    }
}
