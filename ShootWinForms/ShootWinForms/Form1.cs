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
    public partial class Form1 : Form
    {
        private Ship playerShip;
        private InvadersManager invadersManager;
        private List<Bullet> bullets = new List<Bullet>();
        private bool goLeft;
        private bool goRight;
        private int score;

        public Form1()
        {
            InitializeComponent();
            gameSetup();

            this.KeyDown += new KeyEventHandler(this.keyisdown);
            this.KeyUp += new KeyEventHandler(this.keyisup);
        }

        private void gameSetup()
        {
            playerShip = new Ship(10);
            playerShip.AddToForm(this);

            invadersManager = new InvadersManager();
            invadersManager.InitializeInvaders(this);

            //GameTimer
            gameTimer.Tick += new EventHandler(mainGameTimerEvent);
            gameTimer.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft) playerShip.MoveLeft();
            if (goRight) playerShip.MoveRight();

            // Mouvement des Invaders et Bullets
            invadersManager.MoveInvaders();
            MoveBullets();
            CheckBulletCollisions();
        }
        private void MoveBullets()
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Move();

                if (bullets[i].IsOffScreen())
                {
                    bullets[i].RemoveFromForm(this);
                    bullets.RemoveAt(i);
                }
            }
        }
        private void CheckBulletCollisions()
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var bullet = bullets[i];
                for (int j = invadersManager.InvadersList.Count - 1; j >= 0; j--)
                {
                    var invader = invadersManager.InvadersList[j];
                    if (bullet.BulletPictureBox.Bounds.IntersectsWith(invader.InvaderPictureBox.Bounds))
                    {
                        bullet.RemoveFromForm(this);
                        bullets.RemoveAt(i);

                        invader.InvaderPictureBox.Dispose();
                        invadersManager.InvadersList.RemoveAt(j);

                        //Update Score
                        score++;
                        txtScore.Text = "Score: " + score;

                        break;
                    }
                }
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Space)
            {
                Bullet newBullet = new Bullet(
                    new Point(playerShip.ShipPictureBox.Left + (playerShip.ShipPictureBox.Width / 2) - 5, playerShip.ShipPictureBox.Top - 20),
                    speed: 20,
                    image: Properties.Resources.PixelLazer
                );

                newBullet.AddToForm(this);
                bullets.Add(newBullet);
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
        }
    }
}
