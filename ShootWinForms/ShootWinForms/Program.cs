///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Main program class that serves as the entry point for the ShootWinForms application

using System;
using System.Windows.Forms;

namespace ShootWinForms
{
    /// <summary>
    /// Static class containing the main entry point for the application
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This method is called when the application starts.
        /// It sets up the visual styles and launches the main menu form.
        /// </summary>
        [STAThread] // Indicates that the COM threading model for the application is single-threaded apartment
        static void Main()
        {
            // Enable visual styles for the application
            // This allows the application to use the current Windows theme
            Application.EnableVisualStyles();

            // Set the default text rendering to be compatible with GDI+
            // This ensures consistent text rendering across different Windows versions
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run the main menu form
            // This starts the application's message loop and displays the main menu
            Application.Run(new MenuForm());
        }
    }
}