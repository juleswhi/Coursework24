using Chess;
using ChessMasterQuiz.Forms;

namespace ChessMasterQuiz
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

            goto main;
            PgnReader reader = new();

            reader.FromBytes(
                PGNLibrary.Steinitz_Best_Games
                );

            main:
            Application.Run(new formChessboard());


        }
    }
}