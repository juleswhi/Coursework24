using ChessMasterQuiz.Misc;

namespace Chess;

public class Puzzle : Question
{
    static Puzzle()
    {
        CreatePuzzles();
    }
    public Puzzle()
    {
        Setup = default;
        Moves = default;
    }
    public static List<Puzzle> Puzzles { get; set; } = new();
    public override int Rating { get; init; }
    public Colour ToMove { get; set; }
    public IEnumerable<Piece>? Setup { get; set; }
    public List<string>? Moves { get; set; }
    public int CorrectMove { get; set; }
    public static void CreatePuzzles()
    {
        Puzzles = ReadPuzzles();
    }
}

