using Domain;
using Domain.Holidays;
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
            Point london = new Point(x: 0.0, y: 0.0);
            Point manchester = new Point(x: 2.0, y: 2.0);

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(london, manchester);

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
            var a = Earth.London;
            var b = Earth.Paris;
            var c = Earth.Berlin;
            Route londonToBerlinViaParis = new Route("London", "Berlin", new [] { a, b, c });

            // Act
            var planner = new RoutePlanner();
            var distance = planner.CalculateDistance(londonToBerlinViaParis);

            // Assert
            Assert.AreEqual(0.0, distance, 0.01);
            Assert.AreEqual(0.0, londonToBerlinViaParis.Distance, 0.01);
        }

        [Test]
        public void CanWorkOutShortestRoute()
        {
            // Arrange
            var manchesterToBerlinViaAmsterdam = new Route("Manchester", "Berlin", new [] { Earth.Manchester, Earth.Amsterdam, Earth.Berlin });
            var manchesterToBerlinViaLondonAndAmsterdam = new Route("Manchester", "Berlin", new[] { Earth.Manchester, Earth.London, Earth.Amsterdam, Earth.Berlin });

            // Act
            var planner = new RoutePlanner();
            var shortest =
                planner.FindShortestRoute(
                    new[] { manchesterToBerlinViaAmsterdam, manchesterToBerlinViaLondonAndAmsterdam }, 
                    "Manchester", "Berlin");

            // Assert - returned route is from Manchester to Berlin
            Assert.AreEqual("Manchester", shortest.Origin);
            Assert.AreEqual("Berlin", shortest.Destination);

            CollectionAssert.AreEqual(new[] { Earth.Manchester, Earth.Amsterdam, Earth.Berlin }, shortest.Points);
        }

        [Test]
        public void CanWorkOutShortestRoute_FromMadrid()
        {
            // Arrange
            var manchesterToRomeViaBrussels = new Route("Manchester", "Rome", new[] { Earth.Manchester, Earth.Brussels, Earth.Rome });
            var manchesterToRomeViaParis = new Route("Manchester", "Rome", new[] { Earth.Manchester, Earth.Paris, Earth.Rome });

            // Act
            var planner = new RoutePlanner();
            var shortest =
                planner.FindShortestRoute(
                    new[] { manchesterToRomeViaBrussels, manchesterToRomeViaParis },
                    "Manchester", "Rome");

            // Assert - returned route is from Manchester to Berlin
            Assert.AreEqual("Manchester", shortest.Origin);
            Assert.AreEqual("Rome", shortest.Destination);

            CollectionAssert.AreEqual(null, shortest.Points);   // replace 'null' with the answer
        }
    }
}
