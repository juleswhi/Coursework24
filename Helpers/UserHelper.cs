using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace ChessMasterQuiz.Helpers;

public static class UserHelper
{
    static readonly string _userpath = "Users.csv";
    public static List<User> Users = new()
    {
        new("root", "password")
    };

    public static User? ActiveUser
    {
        get => Users.FirstOrDefault(x => x.IsLoggedIn == true);
    }


    public static User TestUser => new User("TestUserName", "password", false);

    public static bool VerifyPassword(this string password, User user)
    {
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(password.FromBase64());
        return CryptographicOperations.FixedTimeEquals(
            Rfc2898DeriveBytes.Pbkdf2(passwordInBytes, user.Password!.salt, 100_000, HashAlgorithmName.SHA512, 64)
            , Encoding.UTF8.GetBytes(password));
    }

    public static void Add(this User user)
    {
        Users.Add(user);
    }

    public static void WriteUsers()
    {
        string json = JsonConvert.SerializeObject(Users);
        using (StreamWriter sw = new(_userpath, false))
        {
            sw.Write(json);
        }
    }

    public static void ReadUsers()
    {
        Debug.Print(File.ReadAllLines(_userpath).First());
        Users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllLines(_userpath).First())!;
    }

}
