using static Chess.Colour;
using System.Runtime.CompilerServices;
using Chess;

namespace Chess.BoardRepresentation;

public class Board : FlowLayoutPanel
{
    public static readonly Size _defaultBoardSize = new(400, 400);
    public static readonly Rectangle _defaultRectangle = new Rectangle(new(20, 20), _defaultBoardSize);

    public List<Square> Squares = new();
    public Board() : base()
    {
        // base.BackColor = Color.Gray;
        // Size = _defaultBoardSize;
        // FlowDirection = FlowDirection.LeftToRight;
        Dock = DockStyle.Fill;
        Paint += Draw;

        Invalidate();
    }

    private void Draw(object? sender, PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Blue, _defaultRectangle);
    }
}
