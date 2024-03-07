using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace UserRepresentation;

public static class UserHelper
{
    static readonly string _userpath = "users.json";

    public static List<User> Users => ReadUsers();

    public static List<User> ReadUsers()
    {
        string input = File.ReadAllText(_userpath);

        List<User>? users = JsonSerializer.Deserialize<List<User>>(input);

        if(users is null)
        {
            throw new Exception($"Could not serialize the List of users correctly :(");
        }

        return users;
    }

    public static void UpdateUser(User user)
    {
        List<User> users = Users;

        users.RemoveAll(x => x.Username == user.Username);

        users.Add(user);

        WriteUsers(users);
    }

    public static void WriteUsers()
    {
        UpdateUser(ActiveUser!);
    }

    public static void WriteUsers(List<User>? u)
    {
        string json = JsonSerializer.Serialize(u);

        File.WriteAllText(_userpath, json);
    }

    public static User? ActiveUser
    {
        get;
        set;
    }

    public static string SerializePassword(this Password password)
    {
        StringBuilder sb = new();

        sb.Append($"{nameof(password.Hashed)}{{{password.Hashed}}}");

        sb.Append($"{nameof(password.Salt)}{{{Encoding.UTF8.GetString(password.Salt)}}}");

        return sb.ToString();
    }


    public static User TestUser => new User("root", "root", false)
    {
        Name = "Root User",
        Gender = "N/A",
    };

    public static bool VerifyPassword(this string password, User user)
    {
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);

        var hashedPassword =
                    Rfc2898DeriveBytes.Pbkdf2(passwordInBytes,
                        user.Password!.Salt,
                        100_000,
                        HashAlgorithmName.SHA512,
                        64);

        if (Encoding.UTF8.GetString(hashedPassword) == user.Password.Hashed)
        {
            return true;
        }
        return false;
    }

    public static void Add(this User user)
    {
        Users.Add(user);
    }
}
