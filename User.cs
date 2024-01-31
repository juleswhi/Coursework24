using static ChessMasterQuiz.Helper;
using System.Security.Cryptography;
using static ChessMasterQuiz.UserType;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace ChessMasterQuiz;

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
public record Password(string Hashed, byte[] salt);

// This class handles representation of the User model.
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

    // Reference to the image found in "Forms/ProfilePictures.resx"
    public string ImageName { get; set; } = string.Empty;

    // Bool value to validate who is logged in
    public bool IsLoggedIn { get; private set; }


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
                Convert.ToBase64String(
                    Rfc2898DeriveBytes.Pbkdf2(passwordInBytes,
                        salt,
                        100_000,
                        HashAlgorithmName.SHA512,
                        64));
        
        // Creates the password object with the hashedPassword and the salt.
        Password = new(
                hashedPassword,
                salt
            );
        
        // The type is inferred from the bool isAdmin
        Type = isAdmin ? ADMIN : USER;
    }

    // This method double checks that all users are logged out before logging in a specific user.
    public void Login() {
        foreach(var user in Users) {
            user.Logout();
        }
        IsLoggedIn = true;
    }

    // Logs the user out by simply chaning their `IsLoggedIn` property.
    public void Logout() {
        IsLoggedIn = false;
    }

}
