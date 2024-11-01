///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : Main game class containing the core game logic and functionality
///              Includes options for starting the game, viewing highscores,
///              accessing settings, and about information.

// Required system namespaces for basic functionality
using System;
using System.Collections.Generic;   // For List<T> collections
using System.ComponentModel;        // For component model features
using System.Data;                  // For data handling
using System.Drawing;               // For graphics and drawing
using System.Linq;                  // For LINQ queries
using System.Text;                  // For text handling
using System.Threading.Tasks;       // For asynchronous operations
using System.Windows.Forms;         // For Windows Forms UI elements

namespace ShootWinForms
{
    /// <summary>
    /// Main game form class that serves as the primary container for all game elements
    /// Manages core gameplay mechanics including:
    /// - Player movement and controls
    /// - Enemy behavior and spawning
    /// - Collision detection between game objects
    /// - Score tracking and game state
    /// - User interface elements
    /// </summary>
    public partial class Form1 : Form
    {
        // ====== GAME ELEMENT DECLARATIONS ======

        // Player ship instance - represents the user-controlled spacecraft
        private Ship playerShip;

        // Manager for enemy invaders - handles enemy movement, spawning, and behavior
        private InvadersManager invadersManager;

        // Collection of active player bullets on screen
        // Updated continuously during gameplay
        private List<Bullet> bullets = new List<Bullet>();

        // Collection of active enemy bullets on screen
        // Managed separately from player bullets for distinct behavior
        private List<Bullet> enemyBullets = new List<Bullet>();

        // Collection of protective obstacles on the game field
        // Provides cover for the player from enemy fire
        private List<Obstacle> obstacles = new List<Obstacle>();

        // ====== MOVEMENT AND CONTROL FLAGS ======

        // Flag indicating if the player is moving left
        // Set by keyboard input handling
        private bool goLeft;

        // Flag indicating if the player is moving right
        // Set by keyboard input handling
        private bool goRight;

        // Current player score in the game
        // Incremented when destroying enemies
        private int score;

        // Flag indicating if the player is currently shooting
        // Controls bullet firing mechanics
        private bool shooting;

        /// <summary>
        /// Form1 Constructor
        /// Initializes the game window and sets up all necessary game components
        /// Establishes event handlers and initializes game state
        /// </summary>
        public Form1()
        {
            // Initialize all form components from the designer
            InitializeComponent();

            // Set up core game elements and systems
            gameSetup();

            // Create and position obstacles on the game field
            InitializeObstacles();

            // ====== EVENT HANDLER SETUP ======

            // Register keyboard event handlers for player input
            // KeyDown event - triggered when a key is pressed
            this.KeyDown += new KeyEventHandler(this.keyisdown);

            // KeyUp event - triggered when a key is released
            this.KeyUp += new KeyEventHandler(this.keyisup);

            // Register form closing event handler
            // Ensures proper cleanup when the game exits
            this.FormClosing += Form1_FormClosing;
        }

        /// <summary>
        /// Initializes core game components and systems
        /// Sets up the player ship, enemies, and starts the game timer
        /// </summary>
        private void gameSetup()
        {
            // ====== PLAYER INITIALIZATION ======

            // Create new player ship with initial health value
            playerShip = new Ship(10);

            // Add the player ship's visual representation to the game form
            playerShip.AddToForm(this);

            // ====== ENEMY INITIALIZATION ======

            // Create the enemy manager instance
            invadersManager = new InvadersManager();

            // Initialize and position all enemy invaders
            invadersManager.InitializeInvaders(this);

            // ====== GAME TIMER SETUP ======

            // Register the main game loop event handler
            gameTimer.Tick += new EventHandler(mainGameTimerEvent);

            // Start the game timer to begin the game loop
            gameTimer.Start();
        }

        /// <summary>
        /// Form load event handler
        /// Currently empty but available for additional initialization if needed
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Reserved for future implementation
        }

        /// <summary>
        /// Main game loop - executed on each timer tick
        /// Handles all continuous game updates including:
        /// - Player movement
        /// - Enemy behavior
        /// - Collision detection
        /// - Game state updates
        /// </summary>
        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            // ====== PLAYER MOVEMENT HANDLING ======

            // Process left movement if the left flag is active
            if (goLeft) playerShip.MoveLeft();

            // Process right movement if the right flag is active
            if (goRight) playerShip.MoveRight();

            // ====== BOUNDARY CHECKING ======

            // Prevent player from moving beyond left screen boundary
            if (playerShip.ShipPictureBox.Left <= 0)
            {
                playerShip.ShipPictureBox.Left = 0;
            }

            // Prevent player from moving beyond right screen boundary
            if (playerShip.ShipPictureBox.Right >= this.ClientSize.Width)
            {
                playerShip.ShipPictureBox.Left = this.ClientSize.Width - playerShip.ShipPictureBox.Width;
            }


            // ====== ENEMY SHOOTING LOGIC ======

            // Attempt to generate an enemy bullet based on game conditions
            Bullet enemyBullet = invadersManager.TryEnemyShoot();

            // If an enemy bullet was successfully created
            if (enemyBullet != null)
            {
                // Add the bullet's visual representation to the game form
                this.Controls.Add(enemyBullet.BulletPictureBox);

                // Add the bullet to the collection of active enemy projectiles
                enemyBullets.Add(enemyBullet);
            }

            // ====== GAME STATE UPDATES ======

            // Update positions and states of all active bullets
            MoveBullets();

            // Process enemy bullet movement
            MoveEnemyBullets();

            // Check for collisions between player bullets and enemies
            CheckBulletCollisions();

            // Check for collisions between bullets and obstacles
            CheckBulletObstacleCollisions();

            // Check for collisions between enemy bullets and player
            CheckEnemyBulletCollisions();

            // Update enemy positions and behavior
            invadersManager.MoveInvaders(this);

            // ====== PLAYER SHOOTING LOGIC ======

            // Process player shooting if the shooting flag is active
            if (shooting)
            {
                // Attempt to create a new bullet from the player's position
                Bullet newBullet = playerShip.Shoot();

                // If bullet creation was successful
                if (newBullet != null)
                {
                    // ====== BULLET INITIALIZATION ======

                    // Configure the new bullet with position, speed, and appearance
                    Bullet.GetBullet(
                        // Calculate bullet starting position relative to player ship
                        new Point(
                            playerShip.ShipPictureBox.Left + (playerShip.ShipPictureBox.Width / 2) - 5,
                            playerShip.ShipPictureBox.Top - 20
                        ),
                        speed: 20,  // Set bullet velocity
                        image: Properties.Resources.PixelLazer  // Set bullet appearance
                    );

                    // Ensure the bullet is visible on screen
                    if (!newBullet.BulletPictureBox.Visible)
                    {
                        newBullet.BulletPictureBox.Visible = true;
                    }

                    // Add bullet to the game form and active bullets collection
                    this.Controls.Add(newBullet.BulletPictureBox);
                    bullets.Add(newBullet);
                }
            }
        }

        /// <summary>
        /// Manages the movement and lifecycle of player bullets
        /// Handles bullet removal when they leave the screen
        /// </summary>
        private void MoveBullets()
        {
            // Iterate through bullets from last to first to safely remove items
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                // Get the current bullet
                Bullet bullet = bullets[i];

                // Update bullet position
                bullet.Move();

                // Check if bullet has moved off screen
                if (bullet.IsOffScreen())
                {
                    // Deactivate the bullet
                    bullet.Deactivate();

                    // Return bullet to object pool for reuse
                    Bullet.ReturnBullet(bullet);

                    // Remove from active bullets collection
                    bullets.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Handles collision detection between player bullets and enemies
        /// Updates score and removes destroyed objects
        /// </summary>
        private void CheckBulletCollisions()
        {
            // Iterate through all active bullets
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = bullets[i];

                // Skip if bullet has been disposed
                if (bullet.BulletPictureBox.IsDisposed)
                {
                    bullets.RemoveAt(i);
                    continue;
                }

                // Check collision with each invader
                for (int j = invadersManager.InvadersList.Count - 1; j >= 0; j--)
                {
                    Invader invader = invadersManager.InvadersList[j];

                    // Skip if invader has been disposed
                    if (invader.InvaderPictureBox.IsDisposed)
                    {
                        invadersManager.InvadersList.RemoveAt(j);
                        continue;
                    }

                    // ====== COLLISION DETECTION ======

                    // Check if bullet intersects with invader
                    if (bullet.BulletPictureBox.Bounds.IntersectsWith(invader.InvaderPictureBox.Bounds))
                    {
                        // ====== COLLISION HANDLING ======

                        // Cleanup bullet
                        bullet.Deactivate();
                        Bullet.ReturnBullet(bullet);
                        bullets.RemoveAt(i);

                        // Remove destroyed invader
                        this.Controls.Remove(invader.InvaderPictureBox);
                        invader.InvaderPictureBox.Dispose();
                        invadersManager.InvadersList.RemoveAt(j);

                        // Update score
                        score++;
                        txtScore.Text = "Score: " + score;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles keyboard key press events
        /// Updates movement and shooting flags based on input
        /// </summary>
        private void keyisdown(object sender, KeyEventArgs e)
        {
            // Set movement flags based on arrow key input
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;

            // Set shooting flag when space is pressed
            if (e.KeyCode == Keys.Space) shooting = true;
        }

        /// <summary>
        /// Handles keyboard key release events
        /// Resets movement and shooting flags when keys are released
        /// </summary>
        private void keyisup(object sender, KeyEventArgs e)
        {
            // Reset movement flags when arrow keys are released
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;

            // Reset shooting flag when space is released
            if (e.KeyCode == Keys.Space) shooting = false;
        }


        /// <summary>
        /// Handles form closing event
        /// Ensures proper application shutdown
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Terminate the application cleanly
            Application.Exit();
        }

        /// <summary>
        /// Initializes and positions obstacles on the game field
        /// Creates protective barriers for the player
        /// </summary>
        private void InitializeObstacles()
        {
            // Initialize obstacles collection
            obstacles = new List<Obstacle>();

            // Define obstacle positions relative to screen size
            Point[] positions = {
                new Point(100, this.ClientSize.Height - 150),                  // Left obstacle
                new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height - 150), // Center obstacle
                new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 150)     // Right obstacle
            };

            // Define standard size for all obstacles
            Size obstacleSize = new Size(100, 20);

            // Create and place each obstacle
            foreach (Point position in positions)
            {
                // Create new obstacle with specified properties
                Obstacle obstacle = new Obstacle(position, obstacleSize, initialHealth: 40);

                // Add to obstacles collection
                obstacles.Add(obstacle);

                // Add visual representation to game form
                this.Controls.Add(obstacle.ObstaclePictureBox);
            }
        }

        /// <summary>
        /// Updates positions of enemy bullets and handles cleanup
        /// Removes bullets that move off screen
        /// </summary>
        private void MoveEnemyBullets()
        {
            // Process each enemy bullet
            for (int i = enemyBullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = enemyBullets[i];

                // Skip if bullet has been disposed
                if (bullet.BulletPictureBox.IsDisposed)
                {
                    enemyBullets.RemoveAt(i);
                    continue;
                }

                // Update bullet position
                bullet.Move();

                // Check if bullet has moved off screen
                if (bullet.BulletPictureBox.Top > this.ClientSize.Height)
                {
                    // Deactivate and recycle the bullet
                    bullet.Deactivate();
                    Bullet.ReturnBullet(bullet);
                    enemyBullets.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Checks for collisions between enemy bullets and the player ship
        /// Handles player damage and game over logic
        /// </summary>
        private void CheckEnemyBulletCollisions()
        {
            // Process each enemy bullet
            for (int i = enemyBullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = enemyBullets[i];

                // Skip if bullet has been disposed
                if (bullet.BulletPictureBox.IsDisposed)
                {
                    enemyBullets.RemoveAt(i);
                    continue;
                }

                // Check for intersection with player ship
                if (bullet.BulletPictureBox.Bounds.IntersectsWith(playerShip.ShipPictureBox.Bounds))
                {
                    // Handle bullet cleanup
                    bullet.Deactivate();
                    Bullet.ReturnBullet(bullet);
                    enemyBullets.RemoveAt(i);

                    // Reduce player lives
                    Ship.playerLives--;
                    livesLabel.Text = "Lives: " + Ship.playerLives;

                    // Check for game over
                    if (Ship.playerLives == 0)
                    {
                        GameOver();
                    }
                }
            }
        }

        /// <summary>
        /// Checks for collisions between bullets and obstacles
        /// Handles bullet destruction and obstacle damage
        /// </summary>
        private void CheckBulletObstacleCollisions()
        {
            // Get all active bullets on screen
            var bulletControls = this.Controls.OfType<PictureBox>()
                .Where(x => x.Tag?.ToString() == "bullet" && !x.IsDisposed)
                .ToList();

            // Process each bullet
            foreach (PictureBox bullet in bulletControls)
            {
                // Process each obstacle
                foreach (Obstacle obstacle in obstacles.ToList())
                {
                    // Skip if obstacle has been disposed
                    if (obstacle.ObstaclePictureBox.IsDisposed)
                        continue;

                    // Check for collision between bullet and obstacle
                    if (obstacle.HandleCollision(bullet))
                    {
                        // Handle bullet cleanup
                        if (!bullet.IsDisposed)
                        {
                            bullet.Visible = false;
                            this.Controls.Remove(bullet);
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles game over logic and displays final score
        /// </summary>
        private void GameOver()
        {
            // Stop the game timer
            gameTimer.Stop();

            // Display final score and game over message
            MessageBox.Show("Game Over! Score: " + score);

            // Close the game form
            this.Close();
        }
    }
}