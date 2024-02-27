using ChessMasterQuiz.Chess;
using static Chess.ChessHelper;
using static Chess.Colour;

namespace Chess.BoardRepresentation;

public class Board : Panel
{
    public Piece? this[char file, int rank] =>
        Pieces.FirstOrDefault(x => x.Location! == Notation.From(file, rank));
    public Piece? this[SAN location] =>
        Pieces.FirstOrDefault(x => x.Location!.ToString() == location.GetNotation());
    public Piece? this[string location] =>
        Pieces.FirstOrDefault(x => x.Location!.Equals(location));


    private static readonly Size _defaultBoardSize = new(400, 400);
    private int _squareWidth => this.Size.Width / 8;

    private KeyValuePair<Square?, Square?> SelectedSquares = new(null, null);

    public List<Square> Squares = new();
    public List<Piece> Pieces = new();
    public Board(Size? size = null) : base()
    {
        MoveHelper.CurrentBoard = this;
        base.BackColor = Color.Gray;
        size ??= _defaultBoardSize;
        Size = (Size)size;

        for(int i = 0; i < 8; i++)
        {
            for(int j = 8; j >= 0; j--)
            {
                Squares.Add(
                    // Obfuscation so you can't ever understand this
                    // Documentation can be found in hell
                    new Square(
                        (i + j) % 2 == 0
                            ? White
                            : Black,
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

            Point roundedPoint = new Point(

                (int)Math.Floor(pos.X / 50m) * 50,
                (int)Math.Floor(pos.Y / 50m) * 50
                );

            foreach(var square in Squares)
            {
                if(square.Location == roundedPoint)
                {
                    SelectedSquares = new(square, SelectedSquares.Value);
                }
            }

            Invalidate();
        };

        Invalidate();
    }


    private void Draw(object? sender, PaintEventArgs e)
    {
        foreach (var square in Squares)
        {
            e.Graphics.FillRectangle(
                square.Colour == White ? Brushes.LightGray : Brushes.DarkGray,
                new Rectangle(square.Location, new(50, 50))
            );

            if (SelectedSquares.Key is Square key)
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


    public void DisplayGame(PGN pgn, int PlyPause = -1)
    {
        Thread gameThread = new Thread(() =>
        {
        });
        gameThread.Start();

    }
}
