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
        new("root", "root")
        {
            Email = new System.Net.Mail.MailAddress("root@root.com"),
        }
    };

    public static User? ActiveUser
    {
        get => Users.FirstOrDefault(x => x.IsLoggedIn == true);
    }

    public static string SerializePassword(this Password password)
    {
        StringBuilder sb = new();

        sb.Append($"{nameof(password.Hashed)}{{{password.Hashed}}}");

        sb.Append($"{nameof(password.Salt)}{{{Encoding.UTF8.GetString(password.Salt)}}}");

        return sb.ToString();
    }


    public static User TestUser => new User("TestUserName", "password", false);

    public static bool VerifyPassword(this string password, User user)
    {
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);

        var hashedPassword = 
                    Rfc2898DeriveBytes.Pbkdf2(passwordInBytes,
                        user.Password!.Salt,
                        100_000,
                        HashAlgorithmName.SHA512,
                        64);

        if(Encoding.UTF8.GetString(hashedPassword) == user.Password.Hashed)
        {
            return true;
        }
        return false;
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
