///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Ship class that manages the player's ship in the game
///              Includes functionality for movement, shooting, and ship initialization.

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
    /// This class represents the player's ship in the game
    /// </summary>
    internal class Ship
    {
        /// <summary>
        /// The visual representation of the ship
        /// </summary>
        public PictureBox ShipPictureBox { get; private set; }

        /// <summary>
        /// The movement speed of the ship
        /// </summary>
        private int _speed;

        /// <summary>
        /// Time in milliseconds between shots
        /// </summary>
        private int shootCooldown = 500;

        /// <summary>
        /// Number of lives the player has
        /// </summary>
        public static int playerLives = 5;

        /// <summary>
        /// Tracks the time of the last shot for cooldown purposes
        /// </summary>
        private DateTime lastShotTime = DateTime.MinValue;

        /// <summary>
        /// Constructor for the ship class
        /// </summary>
        /// <param name="speed">Initial movement speed of the ship</param>
        public Ship(int speed)
        {
            _speed = speed;
            InitializeShip();
        }

        /// <summary>
        /// Initializes the ship's visual properties and starting position
        /// </summary>
        private void InitializeShip()
        {
            ShipPictureBox = new PictureBox();
            {
                ShipPictureBox.Size = new Size(40, 40);
                ShipPictureBox.Image = Properties.Resources.shipViolet;
                ShipPictureBox.Top = 500;
                ShipPictureBox.Left = 350;
                ShipPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ShipPictureBox.Tag = "player";
            };
        }

        /// <summary>
        /// Moves the ship to the left by the speed amount
        /// </summary>
        public void MoveLeft() => ShipPictureBox.Left -= _speed;

        /// <summary>
        /// Moves the ship to the right by the speed amount
        /// </summary>
        public void MoveRight() => ShipPictureBox.Left += _speed;

        /// <summary>
        /// Adds the ship to the specified form
        /// </summary>
        /// <param name="form">The form to add the ship to</param>
        public void AddToForm(Form form)
        {
            if (ShipPictureBox != null)
            {
                form.Controls.Add(ShipPictureBox);
            }
        }

        /// <summary>
        /// Creates a new bullet if the cooldown period has elapsed
        /// </summary>
        /// <returns>A new Bullet object if cooldown has elapsed, null otherwise</returns>
        public Bullet Shoot()
        {
            // Check if enough time has passed since the last shot
            if (DateTime.Now - lastShotTime >= TimeSpan.FromMilliseconds(shootCooldown))
            {
                lastShotTime = DateTime.Now;
                return Bullet.GetBullet(
                    new Point(ShipPictureBox.Left + (ShipPictureBox.Width / 2) - 5,
                             ShipPictureBox.Top - 20),
                    10,
                    Properties.Resources.PixelLazer // Bullet image
                );
            }
            return null; // Return null if we can't shoot yet
        }
    }
}