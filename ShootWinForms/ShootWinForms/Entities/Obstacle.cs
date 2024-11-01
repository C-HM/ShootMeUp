///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Obstacle class that manages individual obstacle objects in the game
///              Includes functionality for handling collisions, taking damage, and updating appearance.

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
    internal class Obstacle
    {
        // The visual representation of the obstacle
        public PictureBox ObstaclePictureBox { get; private set; }

        // The current health of the obstacle
        public int Health { get; private set; }

        // Flag to indicate if the obstacle has been destroyed
        public bool IsDestroyed { get; private set; }

        // Constant for the amount of damage a bullet does
        private const int BULLET_DAMAGE = 1;

        /// <summary>
        /// Constructor for creating a new obstacle
        /// </summary>
        /// <param name="position">The position of the obstacle on the screen</param>
        /// <param name="size">The size of the obstacle</param>
        /// <param name="initialHealth">The initial health of the obstacle</param>
        public Obstacle(Point position, Size size, int initialHealth)
        {
            Health = initialHealth;
            IsDestroyed = false;
            ObstaclePictureBox = new PictureBox
            {
                Location = position,
                Size = size,
                BackColor = Color.Gray,
                Tag = "obstacle"
            };
        }

        /// <summary>
        /// Handles collision between the obstacle and a bullet
        /// </summary>
        /// <param name="bullet">The bullet PictureBox to check collision with</param>
        /// <returns>True if collision occurred, false otherwise</returns>
        public bool HandleCollision(PictureBox bullet)
        {
            // Only check collision if the obstacle is not destroyed
            if (!IsDestroyed && ObstaclePictureBox.Bounds.IntersectsWith(bullet.Bounds))
            {
                TakeDamage(BULLET_DAMAGE);

                // Clean up the bullet
                if (bullet.Parent != null)
                {
                    bullet.Parent.Controls.Remove(bullet);
                }
                bullet.Dispose();

                return true; // Collision occurred
            }
            return false; // No collision
        }

        /// <summary>
        /// Applies damage to the obstacle and updates its appearance
        /// </summary>
        /// <param name="damage">The amount of damage to apply</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            UpdateAppearance();

            if (Health <= 0 && !IsDestroyed)
            {
                IsDestroyed = true;
                // Get the parent form/control
                Control parent = ObstaclePictureBox.Parent;
                if (parent != null)
                {
                    parent.Controls.Remove(ObstaclePictureBox); // Remove from parent controls
                }
                ObstaclePictureBox.Visible = false;
                ObstaclePictureBox.Dispose();
            }
        }

        /// <summary>
        /// Updates the appearance of the obstacle based on its current health
        /// </summary>
        private void UpdateAppearance()
        {
            // Only update appearance if not destroyed
            if (!IsDestroyed)
            {
                if (Health > 30)
                    ObstaclePictureBox.BackColor = Color.Gray;
                else if (Health > 20)
                    ObstaclePictureBox.BackColor = Color.DarkGray;
                else if (Health > 10)
                    ObstaclePictureBox.BackColor = Color.LightGray;
                else
                    ObstaclePictureBox.BackColor = Color.White;
            }
        }
    }
}