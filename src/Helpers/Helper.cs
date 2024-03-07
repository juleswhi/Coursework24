using System.Security.Cryptography;
using ChessMasterQuiz.Misc;

namespace ChessMasterQuiz.Helpers;

public static class Helper
{
    private static Random _random = new Random();
    public static Action EmptyAction => new Action(() => { });
    public static Action<T> EmptyActionGeneric<T>() => new Action<T>((_) => { });
    public static Action<Ti, Tj> EmptyActionGeneric<Ti, Tj>() => new Action<Ti, Tj>((_, _) => { });
    public static void MainMenu() => ActivateForm<formMenu>();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
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
}
