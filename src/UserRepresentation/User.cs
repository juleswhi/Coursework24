using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using ChessMasterQuiz.Chess;

namespace UserRepresentation;

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

    // This `Username` represents a unique username to identify the user
    public string? Username { get; set; } = null;

    // Gender is a string for inclusivity 
    public string Gender { get; set; } = string.Empty;

    // The Date of birth of the user
    public DateTime DOB { get; set; }
    // The email of the representative user
    public MailAddress? Email { get; set; }

    // The `UserType` can either be Admin or User 
    public UserType Type { get; set; } = UserType.USER;

    // The current rating of the user 
    public ELO Elo { get; set; } = new();

    // A percentage representing the users accuracy
    public float Accuracy { get; set; } = 100;

    // Represents the most questions answered in a single round for a particular user
    public int HighScore { get; set; }

    // Represents the number of questions in a row without a loss
    public int CorrectAnswersInRow { get; set; } = 0;

    // The amount of quizs the user has completed
    public int QuizesCompleted { get; set; }

    // Reference to the image found in "Forms/ProfilePictures.resx"
    public int ImageIndex { get; set; } = 0;

    // Bool value to validate who is logged in
    public bool IsLoggedIn { get; private set; }

    public static IReadOnlyList<Image> ProfilePictures { get; }

    public User()
    { }

    static User()
    {
        ProfilePictures = new List<Image>()
        {
            ChessPieces.WhitePawn,
            ChessPieces.WhiteKnight,
            ChessPieces.WhiteBishop,
            ChessPieces.WhiteRook,
            ChessPieces.WhiteQueen,
            ChessPieces.WhiteKing,
            ChessPieces.BlackPawn,
            ChessPieces.BlackKnight,
            ChessPieces.BlackBishop,
            ChessPieces.BlackRook,
            ChessPieces.BlackQueen,
            ChessPieces.BlackKing
        };
    }

    // Constructor for the User class takes a plain text password and stores it as a hash
    public User(string name, string password, bool isAdmin = false)
    {
        Username = name;

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
        Type = isAdmin ? UserType.ADMIN : UserType.USER;
    }


    // This method double checks that all users are logged out before logging in a specific user.
    public void Login()
    {
        foreach (var user in Users)
        {
            user.Logout();
        }
        IsLoggedIn = true;
        ActiveUser = this;
    }

    // Logs the user out by simply chaning their `IsLoggedIn` property.
    public void Logout()
    {
        IsLoggedIn = false;
        ActiveUser = null;
    }
}
