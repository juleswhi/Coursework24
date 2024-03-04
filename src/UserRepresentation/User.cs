using static ChessMasterQuiz.UserRepresentation.UserHelper;
using static ChessMasterQuiz.Helper;
using System.Security.Cryptography;
using static ChessMasterQuiz.UserRepresentation.UserType;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace User;

// This enum is used to identify a regular user from an admin
// This is done through a property in the User class ( User.cs, line 25 )

public enum UserType
{
    USER,
    ADMIN
}

// This is a record type for a password
// A record type is vastly similar to a class, but does most of the boring work for you.
// The values in the "()" are automatically properties of the record type.
// In addition to a class, records are reference types.
[Serializable]
public record Password(string Hashed, byte[] Salt);

// This class handles representation of the User model.
[Serializable]
public class User
{
    // `Name` is the username of the user. Note: Not Unique
    public string Name { get; set; } = string.Empty;

    // A `Password` record is used to store not only the hashed password, but also the salt 
    public Password? Password { get; set; } = null;

    // This `MailAddress` type represents an email address
    public MailAddress? Email { get; set; } = null;

    // Gender is a string for inclusivity 
    public string Gender { get; set; } = string.Empty;

    // The `UserType` can either be Admin or User 
    public UserType Type { get; set; } = USER;

    // The current rating of the user 
    public ELO Elo { get; set; } = new();

    // Reference to the image found in "Forms/ProfilePictures.resx"
    public string ImageName { get; set; } = string.Empty;

    // Bool value to validate who is logged in
    public bool IsLoggedIn { get; private set; }

    public User()
    { }

    // Constructor for the User class takes a plain text password and stores it as a hash
    public User(string name, string password, bool isAdmin = false)
    {
        Name = name;

        // Generate a random `salt` which is needed for the hashing algorithm to make it more secure
        var salt = RandomNumberGenerator.GetBytes(64);

        // Convert the string `password` to a byte array. This is what the hashing algorithm needs
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);

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
        Password = new(
                Encoding.UTF8.GetString(hashedPassword),
                salt
            );

        // The type is inferred from the bool isAdmin
        Type = isAdmin ? ADMIN : USER;
    }

    // This method double checks that all users are logged out before logging in a specific user.
    public void Login()
    {
        foreach (var user in Users)
        {
            user.Logout();
        }
        IsLoggedIn = true;
    }

    // Logs the user out by simply chaning their `IsLoggedIn` property.
    public void Logout()
    {
        IsLoggedIn = false;
    }

    public string Serialize()
    {
        StringBuilder sb = new();

        // Grab fields

        var fields = typeof(User).GetProperties();

        foreach (var field in fields)
        {
            sb.Append($"{field.Name}{{");
            if (field.Name == "Password")
            {
                var data = field.GetValue(this) as Password;
                sb.Append($"{(field.GetValue(this) as Password)!
.SerializePassword(
                    )}");
            }
            else
            {
                sb.Append(field.GetValue(this));
            }
            sb.Append("}");
        }

        return sb.ToString();
    }

    public static IEnumerable<User> Deserialize(params string[] @string)
    {
        StringBuilder stringBuilder = new();
        foreach (var str in @string)
        {

            User user = new();
            // Parse String
            var current = 0;
            var next = () => current++;

            while (current < str.Length)
            {
                while (str[current] != '{')
                {
                    stringBuilder.Append(str[current]);
                    current++;
                }

                string fieldName = stringBuilder.ToString();
                stringBuilder.Clear();

                current++;

                while (str[current] != '}')
                {
                    stringBuilder.Append(str[current]);
                    current++;
                }

                current++;
            }

            yield return user;

        }
    }

}
