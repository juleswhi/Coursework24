using static Chess.Colour;
using System.Runtime.CompilerServices;
using Chess;
using System.Diagnostics;

namespace Chess.BoardRepresentation;

public class Board : Panel
{
    public static readonly Size _defaultBoardSize = new(400, 400);
    public static readonly Rectangle _defaultRectangle = new Rectangle(new(20, 20), _defaultBoardSize);
    public static readonly int _defaultSquareWidth = 50;

    public List<Square> Squares = new();
    public List<Piece> Pieces = new();
    public Board() : base()
    {
        base.BackColor = Color.Gray;
        Size = _defaultBoardSize;

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                Squares.Add(
                    new Square(
                        (i + j) % 2 == 0
                            ? White
                            : Black,
                        new Point(i * 50, j * 50)
                            ));
            }
        }

        PopulatePieces();

        Paint += Draw;

        Invalidate();
    }

    private void PopulatePieces()
    {
        Pieces.AddRange(

            Enumerable.Range(1, 2)
            .Select(x =>

            Enumerable.Range(1, 8)
                .Select(y => new Piece(
                    (PieceType)1, ((char)(y + 96), x == 1 ? 2 : 7), x == 1 ? White : Black)
                    ).ToList()).Aggregate((x, y) =>
                    {
                        y.AddRange(x);
                        return y;
                    })

            );
    }




    private void Draw(object? sender, PaintEventArgs e)
    {
        // e.Graphics.FillRectangle(Brushes.Blue, _defaultRectangle);

        foreach(var piece in Pieces)
        {
            // Debug.Print($"{piece.Location}");
        }



        foreach (var square in Squares)
        {
            if (square.BoardLocation == ('a', 1))
            {
                e.Graphics.FillRectangle(
                    Brushes.Green,
                    new Rectangle(square.Location, new(50, 50))
                    );
            }
            else
            {

            }
            e.Graphics.FillRectangle(
                square.Colour == White ? Brushes.White : Brushes.Black,
                new Rectangle(square.Location, new(50, 50))
                );

        }
    }
}
