using System.Diagnostics;
using System.Text.Json;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Helpers;

public static class Helper
{
    public static AdminConfiguration? GetAdminConfig()
    {
        return AdminConfiguration.Read();
    } 

    public static Image GetLogo()
    {
        List<Image> images = new()
        {
            GeneralResources.Chess_Logo_1,
            GeneralResources.Chess_Logo_2,
            GeneralResources.Chess_Logo_3,
            GeneralResources.Chess_Logo_4,
            GeneralResources.Chess_Logo_5,
            GeneralResources.Chess_Logo_6,
            GeneralResources.Chess_Logo_7
        };

        return images[_random.Next(-1, images.Count)];
    }

    private static readonly Random _random = new();
    public static Action EmptyAction => new(() => { });
    public static Action<T> EmptyActionGeneric<T>()
    {
        return new Action<T>((_) => { });
    }

    public static Action<Ti, Tj> EmptyActionGeneric<Ti, Tj>()
    {
        return new Action<Ti, Tj>((_, _) => { });
    }

    public static void MainMenu()
    {
        ActivateForm<formMenu>();
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static int RatingFromDifficulty(Difficulty diff)
    {
        int @base = diff switch
        {
            Difficulty.HARD => 1800,
            Difficulty.MEDIUM => 1000,
            Difficulty.EASY => 200,
            _ => 2400
        };

        return new Random().Next(@base - 400, @base + 400);
    }

    private const string _puzzlePath = "puzzles.json";

    public static void WritePuzzles(this List<Puzzle> puzzles)
    {
        string json = JsonSerializer.Serialize(puzzles);

        File.WriteAllText(_puzzlePath, json);
    }

    public static List<Puzzle> ReadPuzzles()
    {
        string input = File.ReadAllText(_puzzlePath);

        List<Puzzle>? puzzles = JsonSerializer.Deserialize<List<Puzzle>>(input);

        if (puzzles is null)
        {
            throw new Exception($"Could not deserialize the List of Puzzles correctly :(");
        }

        foreach (var puzzle in puzzles)
        {
            Debug.Print($"{puzzle.Rating}");
        }

        return puzzles;
    }
}


