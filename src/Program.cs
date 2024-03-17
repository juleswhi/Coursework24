using ChessMasterQuiz.Misc;
using WinFormsScraper;
namespace ChessMasterQuiz;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.Run(new formMain());
    }
}