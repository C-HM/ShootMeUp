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
    internal class Invaders
    {
        public PictureBox InvaderPictureBox { get; private set; }
        protected bool CanShoot { get; private set; }

        public Invaders(Size size, Image image, bool canShoot)
        {
            CanShoot = canShoot;
            InvaderPictureBox = new PictureBox
            {
                Size = size,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "invader"
            };
        }

        public void SetPosition(Point position)
        {
            InvaderPictureBox.Location = position;
        }

        public void Move(int speed)
        {
            InvaderPictureBox.Left += speed;
            if (InvaderPictureBox.Left > 730)
            {
                InvaderPictureBox.Top += 65;
                InvaderPictureBox.Left = -80;
            }
        }

        public void AddToForm(Form form)
        {
            form.Controls.Add(InvaderPictureBox);
        }
    }
    internal class Blue : Invaders
    {
        public Blue(Size size) : base(size, Properties.Resources.blue_removebg_preview, true)
        {

        }
    }

    internal class Red : Invaders
    {
        public Red(Size size) : base(size, Properties.Resources.blue_removebg_preview, false)
        {

        }
    }

}
