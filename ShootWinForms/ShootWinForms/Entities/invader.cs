///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Invader class that manages enemy invaders in the game
///              Includes functionality for movement, shooting, and different types of invaders.

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
    /// Base class for all invader types in the game
    /// </summary>
    internal class Invader
    {
        /// <summary>
        /// 
        /// </summary>
        private int _formHeight;
        /// <summary>
        /// The visual representation of the invader
        /// </summary>
        public PictureBox InvaderPictureBox { get; private set; }

        /// <summary>
        /// Determines if this invader type can shoot
        /// </summary>
        protected bool CanShoot { get; private set; }

        /// <summary>
        /// Constructor for creating a new invader
        /// </summary>
        /// <param name="size">The size of the invader</param>
        /// <param name="image">The image to display for the invader</param>
        /// <param name="canShoot">Whether this invader can shoot or not</param>
        public Invader(Size size, Image image, bool canShoot, int formHeight)
        {
            CanShoot = canShoot;
            _formHeight = formHeight;
            InvaderPictureBox = new PictureBox
            {
                Size = size,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "invader"
            };
        }

        /// <summary>
        /// Moves the invader across the screen and down when reaching the edge
        /// </summary>
        /// <param name="speed">The horizontal speed of the invader</param>
        public void Move(int speed)
        {
            InvaderPictureBox.Left += speed;
            // If invader reaches right edge, move down and reset to left side
            if (InvaderPictureBox.Left > 730)
            {
                InvaderPictureBox.Top += 65;
                InvaderPictureBox.Left = -80;
            }
        }

        /// <summary>
        /// Creates a new bullet if the invader can shoot
        /// </summary>
        /// <returns>A new Bullet object if the invader can shoot, null otherwise</returns>
        public Bullet Shoot()
        {
            if (!CanShoot) return null;
            return Bullet.GetBullet(
                new Point(InvaderPictureBox.Left + (InvaderPictureBox.Width / 2) - 5,
                         InvaderPictureBox.Bottom + 10),
                -10,
                Properties.Resources.PixelLazer___reverse,
                _formHeight  // Use the stored form height
            );
        }
    }

    /// <summary>
    /// Blue invader type - cannot shoot
    /// </summary>
    internal class Blue : Invader
    {
        /// <summary>
        /// Constructor for Blue invader
        /// </summary>
        /// <param name="size">The size of the blue invader</param>
        public Blue(Size size, int formHeight) : base(size, Properties.Resources.blue_removebg_preview, false, formHeight) { }
    }

    /// <summary>
    /// Red invader type - can shoot
    /// </summary>
    internal class Red : Invader
    {
        /// <summary>
        /// Constructor for Red invader
        /// </summary>
        /// <param name="size">The size of the red invader</param>
        public Red(Size size, int formHeight) : base(size, Properties.Resources.redinvader, true, formHeight) { }
    }
}