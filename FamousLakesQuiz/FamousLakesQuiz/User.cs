using static FamousLakesQuiz.User.UserType;
using DevOne.Security.Cryptography.BCrypt;
using Newtonsoft.Json;
namespace FamousLakesQuiz;

public record Name(string First, string Last, string[]? Middle);
public record Password(string Hashed, string salt, Func<string, bool> Verify);
internal class User
{
    public enum UserType
    {
        USER,
        ADMIN
    }
    static readonly string UserPath = "Users.csv";
    public Name Name { get; set; } = new("", "", null);
    public Password? Password { get; set; } = null;
    public UserType Type { get; set; } = USER;
    public List<User> Users
    {
        get
        {
            var users = File.ReadAllLines(UserPath);
            return JsonConvert.DeserializeObject<List<User>>(users[0])!; 
        }
        set
        {
            using(StreamWriter sw = new StreamWriter(UserPath, false))
            {
                sw.Write(JsonConvert.SerializeObject(value));
            }
        }
    }

    public User(Name name, string password, bool isAdmin = false)
    {
        Name = name;
        var salt = BCryptHelper.GenerateSalt();
        Password = new(
                BCryptHelper.HashPassword(password, salt),
                salt,
                (password) =>
                {
                    return BCryptHelper.CheckPassword(password, this.Password?.Hashed);
                }
            );
        this.Type = isAdmin ? ADMIN : USER;
    }
}
