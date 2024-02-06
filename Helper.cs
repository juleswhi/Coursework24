using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using ChessMasterObjectNotation;
using static System.Reflection.BindingFlags;
namespace ChessMasterQuiz;
internal static class Helper
{
    public static TextQuestion TestQuestion => new TextQuestion()
    {
        Name = "Location of lakes",
        Difficulty = Difficulty.HARD,
        Q = "Question?",
        A = new Answer(new()
        {
            "rushmore",
            "china",
            "bangladesh",
            "lincoln"
        }, 3)
    };


    public static string ToBase64(this string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }

    public static string FromBase64(this string str)
    {
        var bytes = Convert.FromBase64String(str);
        return Encoding.UTF8.GetString(bytes);
    }

    public static void WriteToFile(List<User> users, string path)
    {
        using(StreamWriter sw = new(path, false))
        {
            sw.WriteLine(JsonConvert.SerializeObject(users));
        }
    }
}
