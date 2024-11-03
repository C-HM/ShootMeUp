///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : MenuForm class that manages the main menu of the game
///              Includes functionality for starting the game, viewing high scores,
///              and exiting the application.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShootWinForms
{
    /// <summary>
    /// Represents the main menu form of the game
    /// </summary>
    public partial class MenuForm : Form
    {
        /// <summary>
        /// Constructor for the MenuForm
        /// Initializes the form and its components
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "Start Game" button click
        /// Creates a new game form, shows it, and hides the menu form
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void gameStart_Click(object sender, EventArgs e)
        {
            // Create a new instance of the game form
            Form1 gameForm = new Form1();
            // Show the game form
            gameForm.Show();
            // Hide the menu form
            this.Hide();
        }

        /// <summary>
        /// Event handler for the "High Scores" button click
        /// Currently displays a placeholder message for future implementation
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void hightscoreButton_Click(object sender, EventArgs e)
        {
            DisplayHighScores();
        }

        /// <summary>
        /// Event handler for the "Exit" button click
        /// Closes the application
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        /// <summary>
        /// Dispaly Highscores
        /// </summary>
        private void DisplayHighScores()
        {
            string path = "highscores.txt";
            List<int> scores = new List<int>();

            if (File.Exists(path))
            {
                scores = File.ReadAllLines(path)
                             .Select(int.Parse)
                             .OrderByDescending(s => s)
                             .Take(5)
                             .ToList();
            }

            string message = "Top 5 High Scores:\n\n";
            for (int i = 0; i < scores.Count; i++)
            {
                message += $"{i + 1}. {scores[i]}\n";
            }

            MessageBox.Show(message, "High Scores");
        }
    }
}