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
            GeneralResources.Chess_Logo_7,
            GeneralResources.Untitled_design,
            GeneralResources.Untitled_design_1_,
            GeneralResources.Untitled_design_2_,
            GeneralResources.Untitled_design_3_,
            GeneralResources.Untitled_design_4_,
            GeneralResources.Untitled_design_5_,
            GeneralResources.Untitled_design_6_,
            GeneralResources.Untitled_design_7_,
            GeneralResources.Untitled_design_8_,
            GeneralResources.Untitled_design_9_,
            GeneralResources.Untitled_design_10_,
            GeneralResources.Untitled_design_11_,
            GeneralResources.Untitled_design_12_,
            GeneralResources.Untitled_design_13_,
            GeneralResources.Untitled_design_14_,
            GeneralResources.Untitled_design_15_,
            GeneralResources.Untitled_design_16_,
            GeneralResources.Untitled_design_17_,
            GeneralResources.Untitled_design_18_,
            GeneralResources.Untitled_design_19_,
            GeneralResources.Untitled_design_20_,
            GeneralResources.Untitled_design_21_,
            GeneralResources.Untitled_design_22_,
            GeneralResources.Untitled_design_23_,
        };

        return images[_random.Next(0, images.Count)];
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

    public static IList<T> Shuffle<T>(this Span<T> list)
    {
        int n = list.Length;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list.ToArray().ToList();
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


