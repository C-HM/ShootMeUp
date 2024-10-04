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
    internal class Bullet
    {
        public PictureBox BulletPictureBox { get; private set; }
        public int Speed { get; private set; }

        public Bullet(Point startPosition, int speed, Image image)
        {
            Speed = speed;
            BulletPictureBox = new PictureBox
            {
                Size = new Size(10, 20),
                Image = image,
                Location = startPosition,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "bullet"
            };
        }

        public void Move()
        {
            BulletPictureBox.Top -= Speed;
        }

        public void AddToForm(Form form)
        {
            form.Controls.Add(BulletPictureBox);
        }

        public bool IsOffScreen()
        {
            return BulletPictureBox.Top < 0;
        }

        public void RemoveFromForm(Form form)
        {
            form.Controls.Remove(BulletPictureBox);
            BulletPictureBox.Dispose();
        }
    }
}
