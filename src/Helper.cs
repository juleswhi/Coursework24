
/*
   This is a generic helper class with some functions and properties to help out in the program
*/

using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using ChessMasterObjectNotation;

namespace ChessMasterQuiz;

public static class Helper
{

    // Creates a new textquestion with some example data for testing purposes
    public static TextQuestion TestQuestion => new TextQuestion()
    {
        Name = "What is the name of the world chess champion?",
        Difficulty = Difficulty.HARD,
        Q = "Question?",
        A = new Answer(new()
        {
            "Magnus Carlsen",
            "Ding Liren",
            "Garry Kasparov",
            "Fabiano Caruana"
        }, 3)
    };


    // Quick and dirty extension method to turn a string to Base 64
    //
    // Could Remove?
    public static string ToBase64(this string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }


    // Sister method to one above
    public static string FromBase64(this string str)
    {
        var bytes = Convert.FromBase64String(str);
        return Encoding.UTF8.GetString(bytes);
    }

    // Writes a list of users to file through json 
    public static void WriteToFile(List<User> users, string path)
    {
        using(StreamWriter sw = new(path, false))
        {
            sw.WriteLine(JsonConvert.SerializeObject(users));
        }
    }
}
