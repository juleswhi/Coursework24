using static FamousLakesQuiz.Helper;
using System.Security.Cryptography;
using static FamousLakesQuiz.UserType;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace FamousLakesQuiz;

public enum UserType
{
    USER,
    ADMIN
}
public record Password(string Hashed, byte[] salt);

internal class User
{

    public string Name { get; set; } = string.Empty;
    public Password? Password { get; set; } = null;
    public MailAddress? Email { get; set; } = null;
    public string Gender { get; set; } = string.Empty;
    public UserType Type { get; set; } = USER;
    public bool IsLoggedIn { get; private set; }


    public User(string name, string password, bool isAdmin = false)
    {
        Name = name;
        var salt = RandomNumberGenerator.GetBytes(64);
        byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);

        
        Password = new(
                Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(passwordInBytes, salt, 100_000, HashAlgorithmName.SHA512, 64)),
                salt
                //(password) =>
                  //  CryptographicOperations.FixedTimeEquals(Rfc2898DeriveBytes.Pbkdf2(passwordInBytes, salt, 100_000, HashAlgorithmName.SHA512, 64), Encoding.UTF8.GetBytes(password))
            );

        Debug.Print(Password.Hashed);
        
        Type = isAdmin ? ADMIN : USER;

        // Write to file

    }

    public void Login() {
        foreach(var user in Users) {
            user.Logout();
        }
        IsLoggedIn = true;
    }

    public void Logout() {
        IsLoggedIn = false;
    }

}
