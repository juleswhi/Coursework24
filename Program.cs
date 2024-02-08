using static ChessMasterQuiz.Helpers.UserHelper;
using System.Data.Common;
using System.Diagnostics;
using System.Text.Json;
using Chess;
using ChessMasterQuiz.Forms;
using ChessMasterQuiz.Helpers;

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
            Application.Run(new formMain());
        }
    }
}