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
    internal class Ship
    {
        public PictureBox ShipPictureBox { get; private set; }
        private int _speed;

        public Ship(int speed)
        {
            _speed = speed;
            InitializeShip();
        }

        private void InitializeShip()
        {
            ShipPictureBox = new PictureBox
            {
                Size = new Size(60, 60),
                Image = Properties.Resources.shipViolet,
                Top = 500,
                Left = 350,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "player"
            };
        }

        public void AddToForm(Form form)
        {
            form.Controls.Add(ShipPictureBox);
        }

        public void MoveLeft()
        {
            ShipPictureBox.Left -= _speed;
        }

        public void MoveRight()
        {
            ShipPictureBox.Left += _speed;
        }

        public void Shoot(Form form)
        {
            var bullet = new Bullet(
                new Point(ShipPictureBox.Left + (ShipPictureBox.Width / 2) - 5, ShipPictureBox.Top - 20),
                speed: 15,
                image: Properties.Resources.PixelLazer
            );

            bullet.AddToForm(form);
        }
    }
}
