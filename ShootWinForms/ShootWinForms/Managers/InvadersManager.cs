///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : InvadersManager class that manages the collection of invaders in the game
///              Includes functionality for initializing, moving, and managing invader shooting.

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
    /// <summary>
    /// Manages the collection of invaders and their behaviors
    /// </summary>
    internal class InvadersManager
    {
        /// <summary>
        /// List of all invaders in the game
        /// </summary>
        public List<Invader> InvadersList { get; private set; }

        /// <summary>
        /// Random number generator for various randomized behaviors
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Flag to determine the direction of invader movement
        /// </summary>
        private bool movingRight = true;

        /// <summary>
        /// Constructor for InvadersManager
        /// </summary>
        public InvadersManager()
        {
            InvadersList = new List<Invader>();
        }

        /// <summary>
        /// Initializes the invaders and adds them to the game form
        /// </summary>
        /// <param name="form">The main game form</param>
        public void InitializeInvaders(Form form)
        {
            for (int i = 0; i < 10; i++)
            {
                Invader invader;
                if (i % 2 == 0)
                {
                    invader = new Blue(new Size(40, 40));
                }
                else
                {
                    invader = new Red(new Size(40, 40));
                }

                // Set the position of the InvaderPictureBox directly
                invader.InvaderPictureBox.Location = new Point(i * 50, 5);

                form.Controls.Add(invader.InvaderPictureBox);
                InvadersList.Add(invader);
            }
        }

        /// <summary>
        /// Moves all invaders and handles boundary checks
        /// </summary>
        /// <param name="form">The main game form</param>
        public void MoveInvaders(Form form)
        {
            int speed = 1; // Adjust the speed as needed
            int boundaryRight = form.ClientSize.Width; // Right boundary, considering invader width
            int boundaryLeft = 0; // Left boundary

            foreach (var invader in InvadersList)
            {
                // Check if invader has reached the boundary
                if (movingRight && invader.InvaderPictureBox.Right >= boundaryRight)
                {
                    movingRight = false;
                    MoveInvadersDown(); // Move down and switch direction
                    break;
                }
                else if (!movingRight && invader.InvaderPictureBox.Left <= boundaryLeft)
                {
                    movingRight = true;
                    MoveInvadersDown(); // Move down and switch direction
                    break;
                }
                invader.Move(movingRight ? speed : -speed);
            }
        }

        /// <summary>
        /// Moves all invaders down by a fixed amount
        /// </summary>
        private void MoveInvadersDown()
        {
            foreach (var invader in InvadersList)
            {
                invader.InvaderPictureBox.Top += 40;
            }
        }

        /// <summary>
        /// Manages invader shooting using the bullet pool
        /// </summary>
        /// <returns>The first active bullet, or null if no invader shoots</returns>
        public Bullet InvaderShooting()
        {
            foreach (Invader invader in InvadersList)
            {
                Bullet bullet = invader.Shoot();
                if (bullet != null)
                {
                    return bullet; // Return only the first active bullet
                }
            }
            return null;
        }

        /// <summary>
        /// Attempts to make an enemy invader shoot
        /// </summary>
        /// <returns>A bullet if an invader shoots, null otherwise</returns>
        public Bullet TryEnemyShoot()
        {
            // Get only red invaders (they can shoot)
            var shootingInvaders = InvadersList.Where(i => i is Red).ToList();

            if (shootingInvaders.Count > 0 && random.Next(100) < 10) // 10% chance to shoot each frame
            {
                // Randomly select a red invader to shoot
                int index = random.Next(shootingInvaders.Count);
                return shootingInvaders[index].Shoot();
            }

            return null;
        }
    }
}