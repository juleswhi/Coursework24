using static ChessMasterQuiz.Helpers.UserHelper;
using System.Data.Common;
using System.Diagnostics;
using System.Text.Json;
using Chess;
using ChessMasterQuiz.Forms;
using ChessMasterQuiz.Helpers;
using ChessMasterQuiz.Chess;

namespace ChessMasterQuiz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new formMain());

        }
    }
}