using static Chess.ChessHelper;
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
            for(int j = 8; j >= 0; j--)
            {
                Squares.Add(
                    // Obfuscation so you can't ever understand this
                    // Documentation can be found in hell
                    new Square(
                        (i + j) % 2 == 0
                            ? White
                            : Black,
                        new Point(i * 50, j * 50),
                        ((char)(i + 97), j + 1)
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
                        PieceType.PAWN, ((char)(y + 96), x == 1 ? 2 : 7), x == 1 ? White : Black)
                        ).ToList()).Aggregate((x, y) =>
                        {
                            y.AddRange(x);
                            return y;
                        })
                );

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(1, 8).Select(
                    x => new Piece(PieceType.ROOK, ((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));


        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(2, 7).Select(
                    x => new Piece(PieceType.KNIGHT, ((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));


        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>

                From(3, 6).Select(
                    x => new Piece(PieceType.BISHOP, ((char)(x + 96), (colour == 1 ? 1 : 8)), (Colour)colour))
                        ).Aggregate((x, y) =>
                        {
                            return y.Concat(x);
                        }
            ));

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>
                    new Piece(PieceType.KING, ('e', (colour == 1 ? 1 : 8)), (Colour)colour))
            );

        Pieces.AddRange(
            Enumerable.Range(1, 2).Select(colour =>
                    new Piece(PieceType.QUEEN, ('d', (colour == 1 ? 1 : 8)), (Colour)colour))
            );
    }

    private void Draw(object? sender, PaintEventArgs e)
    {
        foreach (var square in Squares)
        {

            Debug.Print($"{square.BoardLocation}");
            e.Graphics.FillRectangle(
                square.Colour == White ? Brushes.White : Brushes.Black,
                new Rectangle(square.Location, new(50, 50))
                );

            foreach (var piece in Pieces)
            {
                if (piece.Location == square.BoardLocation)
                {
                    /*
                    e.Graphics.FillRectangle(
                        Brushes.Green,
                        new Rectangle(square.Location, new(50, 50))
                        );
                    */

                    e.Graphics.DrawString($"{piece.Colour}", new Font(FontFamily.GenericMonospace, 10), Brushes.Green, square.Location);
                }
            }


        }
    }
}
