using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ChessMasterQuiz;

namespace UserRepresentation;

public static class UserHelper
{
    static readonly string _userpath = "users.json";
    public static List<User> Users => ReadUsers();

    // get from file
    public static List<User> ReadUsers()
    {
        string input = File.ReadAllText(_userpath);

        List<User>? users = JsonSerializer.Deserialize<List<User>>(input);

        if (users is null)
        {
            ActivateForm<formLogin>();
            return default;
        }

        return users!;
    }

    // Update user reference to file
    public static void UpdateUser(User user)
    {
        if (user is null)
        {
            return;
        }

        List<User> users = Users;

        if (users.Any(x => x.Username == user.Username))
        {
            users.RemoveAll(x => x.Username == user.Username);
        }

        users.Add(user);

        WriteUsers(users);
    }

    public static void WriteUsers()
    {
        UpdateUser(ActiveUser!);
    }

    public static void WriteUser(User user)
    {
        UpdateUser(user);
    }

    // Serialize and write
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

    public static Password Hash(this string pass)
    {
        // Generate a random `salt` which is needed for the hashing algorithm to make it more secure
        var salt = RandomNumberGenerator.GetBytes(64);

        // Convert the string `password` to a byte array. This is what the hashing algorithm needs
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(pass);

        // This snippet hashes the `passwordInBytes` with the `Pbkdf2` hashing algo
        // Then converts the has to Base64, which is useful to put in text
        // The salt is also used to hash the password 
        var hashedPassword =
                    Rfc2898DeriveBytes.Pbkdf2(passwordInBytes,
                        salt,
                        100_000,
                        HashAlgorithmName.SHA512,
                        64);

        // Creates the password object with the hashedPassword and the salt.
        return new(
                Encoding.UTF8.GetString(hashedPassword),
                salt
            );

    }

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
}
