namespace Chess.BoardRepresentation;

public class Square : Panel
{
    public static readonly Size _defaultSquareSize = new(50, 50);
    public (char, int) BoardLocation { get; set; }
    new public Point Location { get; set; } = new();
    public Colour Colour { get; init; }
    public PieceType? Type { get; set; }
    new public Label Text { get; set; } = new();

    public Square(Colour colour, Point location, (char, int) boardLocation) : base()
    {
        Colour = colour;

        BackColor = Colour switch
        {
            Colour.Black => Color.Black,
            Colour.White => Color.White,
            _ => Color.White
        };

        Padding = new(0, 0, 0, 0);
        Margin = new(0, 0, 0, 0);


        BoardLocation = boardLocation;
        Size = _defaultSquareSize;

        Location = location;

        Text.ForeColor = Color.Green;
        // Text.Text = t;

        Controls.Add(Text);
    }
}
