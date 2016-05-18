using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Challenge
    {
        [Test]
        public void CanCalculateHorizontalLineDistance()
        {
            // Arrange - two points on the horizontal axis
            Point a = new Point(0.0, 0.0);
            Point b = new Point(5.0, 0.0);

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(a, b);

            // Assert
            Assert.AreEqual(5.0, distance);
        }

        [Test]
        public void CanCalculateVerticalLineDistance()
        {
            // Arrange - two points on the horizontal axis
            Point a = new Point(0.0, 0.0);
            Point b = new Point(0.0, 7.13);

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(a, b);

            // Assert
            Assert.AreEqual(7.13, distance);
        }

        [Test]
        public void CanCalculateDiagonalDistance()
        {
            // Arrange - two points in space
            Point a = new Point(x: 0.0, y: 0.0);
            Point b = new Point(x: 2.0, y: 2.0);

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(a, b);

            // Assert
            Assert.AreEqual(2.8284271, distance, 0.01);
        }

        [Test]
        public void CanWorkOutDistanceAlongALine()
        {
            // Arrange
            Point a = new Point(x: 0.0, y: 0.0);
            Point b = new Point(x: 0.0, y: 1.0);
            Point c = new Point(x: 2.0, y: 3.0);

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(new[] { a, b, c });

            // Assert
            Assert.AreEqual(1.0 + 2.8284271, distance, 0.01);
        }

        [Test]
        public void CanWorkOutDistanceAlongARoute()
        {
            // Arrange
            Point a = new Point(x: 0.0, y: 0.0);
            Point b = new Point(x: 0.0, y: 1.0);
            Point c = new Point(x: 2.0, y: 3.0);
            Route londonToBerlinViaParis = new Route("London", "Berlin", new [] { a, b, c });

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(londonToBerlinViaParis);

            // Assert
            Assert.AreEqual(1.0 + 2.8284271, distance, 0.01);
            Assert.AreEqual(1.0 + 2.8284271, londonToBerlinViaParis.Distance, 0.01);
        }

        [Test]
        public void CanWorkOutShortestRoute()
        {
            
        }
    }
}
