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
    internal class InvadersManager
    {
        public List<Invaders> InvadersList { get; private set; }

        public InvadersManager()
        {
            InvadersList = new List<Invaders>();
        }

        public void InitializeInvaders(Form form)
        {
            for (int i = 0; i < 10; i++)
            {
                Invaders invader;
                if (i % 2 == 0)
                {
                    invader = new Blue(new Size(60, 60));
                }
                else
                {
                    invader = new Red(new Size(60, 60));
                }


                invader.SetPosition(new Point(i * 80, 5));
                invader.AddToForm(form);
                InvadersList.Add(invader);
            }
        }

        public void MoveInvaders()
        {
            foreach (var invader in InvadersList)
            {
                invader.Move(5);
            }
        }
    }
}
