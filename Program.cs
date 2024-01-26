using QonSerializer;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace FamousLakesQuiz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Debug.WriteLine(Users);
            // Application.Run(new formMain());

            string[] lines = File.ReadAllLines("questions.qon");
            List<Question> questions = QonConvert.DeserializeQuestion(lines);

            Debug.Print(questions[0].Type.ToString());

            Thread.Sleep(10_000);

        }
    }
}