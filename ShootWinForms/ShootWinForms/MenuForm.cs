using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootWinForms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void gameStart_Click(object sender, EventArgs e)
        {
            // Open Form1 (the game form) and hide the menu
            Form1 gameForm = new Form1();
            gameForm.Show();
            this.Hide();
        }

        private void hightscoreButton_Click(object sender, EventArgs e)
        {
            // Open a Scores form or show scores in a message box
            MessageBox.Show("High scores feature coming soon!");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

