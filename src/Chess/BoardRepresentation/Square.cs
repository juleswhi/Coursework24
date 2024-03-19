namespace Chess.BoardRepresentation;

public class Square : Panel
{
    public static readonly Size _defaultSquareSize = new(50, 50);

    // Where the square is on the board ( Notation )
    public (char, int) BoardLocation { get; set; }

    // The screen coords of the square
    new public Point Location { get; set; } = new();
    public Colour Colour { get; init; }
    new public Label Text { get; set; } = new();

    public Square(Colour colour, Point location, (char, int) boardLocation) : base()
    {
        Colour = colour;

        // Their actual colour in terms of winforms
        BackColor = Colour switch
        {
            Black => Color.Black,
            White => Color.White,
            _ => Color.White
        };

        Padding = new(0, 0, 0, 0);
        Margin = new(0, 0, 0, 0);


        BoardLocation = boardLocation;
        Size = _defaultSquareSize;

        Location = location;

        Controls.Add(Text);
    }
}
