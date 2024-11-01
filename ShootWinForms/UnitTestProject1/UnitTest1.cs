///ETML - Section Informatique
///Auteur : Charles-Henri Moser
///Date : 01.11.2024
///Description : This file contains unit tests for the game components, specifically 
///              focusing on the Ship and Obstacle classes. The tests validate the 
///              initialization of the Ship class to ensure it has the correct 
///              properties upon creation, as well as the damage handling and 
///              destruction logic of the Obstacle class. The tests follow the 
///              Arrange-Act-Assert pattern to ensure clarity and maintainability. 
///              This helps in ensuring that the game mechanics function as intended 
///              and aids in future development and debugging.

// Required namespace imports for testing and functionality
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;   // For List<T> collections
using System.ComponentModel;        // For component model features
using System.Data;                  // For data handling
using System.Drawing;              // For graphics and drawing
using System.Linq;                 // For LINQ queries
using System.Text;                 // For text handling
using System.Threading.Tasks;      // For asynchronous operations
using System.Windows.Forms;        // For Windows Forms UI elements
using ShootWinForms;              // Custom namespace for the game

namespace UnitTestProject1
{
    // Test class decorated with TestClass attribute to indicate it contains unit tests
    [TestClass]
    public class GameTests
    {
        /// <summary>
        /// Tests if the ship is correctly initialized with proper position and size
        /// </summary>
        [TestMethod]
        public void Ship_InitializesWithCorrectProperties()
        {
            // Arrange & Act: Create a new ship instance with speed 10
            Ship ship = new Ship(10);

            // Assert: Verify that the ship and its properties are correctly initialized
            Assert.IsNotNull(ship);                              // Check if ship object is created
            Assert.IsNotNull(ship.ShipPictureBox);              // Check if PictureBox is created
            Assert.AreEqual(40, ship.ShipPictureBox.Width);     // Verify correct width
            Assert.AreEqual(40, ship.ShipPictureBox.Height);    // Verify correct height
            Assert.AreEqual(500, ship.ShipPictureBox.Top);      // Verify correct vertical position
            Assert.AreEqual(350, ship.ShipPictureBox.Left);     // Verify correct horizontal position
        }

        /// <summary>
        /// Tests if obstacle takes damage and is destroyed correctly
        /// </summary>
        [TestMethod]
        public void Obstacle_TakesDamageAndDestroysCorrectly()
        {
            // Arrange: Set up the test environment
            Point position = new Point(100, 100);               // Define obstacle position
            Size size = new Size(100, 20);                      // Define obstacle size
            Obstacle obstacle = new Obstacle(position, size, 40); // Create obstacle with 40 health

            // Act: Perform the test actions
            obstacle.TakeDamage(20);  // Apply first damage of 20
            bool partialDamage = obstacle.IsDestroyed;          // Check if destroyed after partial damage

            obstacle.TakeDamage(20);  // Apply second damage of 20
            bool fullyDestroyed = obstacle.IsDestroyed;         // Check if destroyed after full damage

            // Assert: Verify the expected outcomes
            Assert.IsFalse(partialDamage, "Obstacle shouldn't be destroyed after partial damage");
            Assert.IsTrue(fullyDestroyed, "Obstacle should be destroyed after full damage");
        }
    }
}