///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Bullet class that manages individual bullet objects in the game
///              Includes functionality for bullet movement, pooling, initialization,
///              and deactivation of bullets when they go off screen.

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
    /// This class represents a bullet in the game
    /// </summary>
    internal class Bullet
    {
        /// <summary>
        /// Field to store the forms height
        /// </summary>
        private int _formHeight;
        /// <summary>
        /// The visual representation of the bullet
        /// </summary>
        public PictureBox BulletPictureBox { get; private set; }

        /// <summary>
        /// The speed at which the bullet moves
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// A pool of inactive bullets for reuse
        /// </summary>
        private static List<Bullet> bulletPool = new List<Bullet>();

        /// <summary>
        /// Private constructor to prevent direct instantiation
        /// </summary>
        private Bullet() { }

        /// <summary>
        /// Initialize or reinitialize a bullet with given properties
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="speed"></param>
        /// <param name="image"></param>
        public void Initialize(Point startPosition, int speed, Image image, int formHeight)
        {
            Speed = speed;
            _formHeight = formHeight;
            // Create a new PictureBox if it doesn't exist, or reuse the existing one
            BulletPictureBox = BulletPictureBox ?? new PictureBox
            {
                Size = new Size(10, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "bullet"
            };
            BulletPictureBox.Image = image;
            BulletPictureBox.Location = startPosition;
            BulletPictureBox.Visible = true;
        }

        /// <summary>
        /// Move the bullet upwards
        /// </summary>
        public void Move()
        {
            BulletPictureBox.Top -= Speed;

            // Check if the bullet is off screen
            if (IsOffScreen())
            {
                Deactivate();
                ReturnBullet(this);
            }
        }

        /// <summary>
        /// Check if the bullet is off the screen
        /// </summary>
        /// <returns></returns>
        public bool IsOffScreen() => BulletPictureBox.Bottom < 0 || BulletPictureBox.Top > _formHeight;

        /// <summary>
        /// Deactivate the bullet and remove it from the form
        /// </summary>
        public void Deactivate()
        {
            if (!BulletPictureBox.IsDisposed)  // Check if the PictureBox hasn't been disposed
            {
                BulletPictureBox.Visible = false;
                if (BulletPictureBox.Parent != null)
                {
                    BulletPictureBox.Parent.Controls.Remove(BulletPictureBox);
                }
            }
        }

        /// <summary>
        /// Get a bullet from the pool or create a new one if the pool is empty
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="speed"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bullet GetBullet(Point startPosition, int speed, Image image, int formHeight)
        {
            Bullet bullet = bulletPool.Count > 0 ? bulletPool[0] : new Bullet();
            if (bulletPool.Count > 0) bulletPool.RemoveAt(0);
            bullet.Initialize(startPosition, speed, image, formHeight);
            return bullet;
        }

        /// <summary>
        /// Return a bullet to the pool for reuse
        /// </summary>
        /// <param name="bullet"></param>
        public static void ReturnBullet(Bullet bullet)
        {
            if (!bulletPool.Contains(bullet))
            {
                bulletPool.Add(bullet);
            }
        }
    }
}