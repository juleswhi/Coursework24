using System.Text.Json.Serialization;
using ChessMasterQuiz.Misc;

namespace Chess;

public class Puzzle : Question
{
    public Puzzle()
    {
        
    }
    public static List<Puzzle> Puzzles { get; set; } = new();
    public override int Rating { get; init; } 
    public Colour ToMove { get; set; } 
    public IEnumerable<Piece> Setup { get; set; } 
    public List<(string, bool)> Moves { get; set; } 
    public static void CreatePuzzles()
    {
        Puzzles = ReadPuzzles();
    }
}

