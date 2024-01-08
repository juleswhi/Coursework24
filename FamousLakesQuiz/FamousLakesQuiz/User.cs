namespace FamousLakesQuiz;

internal class User
{
    static readonly string UserPath = "Users.csv";
    public List<User> Users
    {
        get
        {
            var a = File.ReadAllLines("");
            return a;
        }
        set
        {

        }
    }
}
