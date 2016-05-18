using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GoingLoopy
    {
        [Test]
        public void GivenAnArray_CanCalculateAverage()
        {
            // Arrange
            LoopyCalculator calc = new LoopyCalculator();

            // Act
            var average = calc.Average(new [] { 2, 3, 4 });

            // Assert
            Assert.AreEqual(3.0, average);
        }

        [Test]
        public void GivenAnArray_CanCalculateSum()
        {
            // Arrange
            LoopyCalculator calc = new LoopyCalculator();

            // Act
            var average = calc.Sum(new[] { 2, 3, 4 });

            // Assert
            Assert.AreEqual(3.0, average);
        }

        [Test]
        public void GivenAnArray_CanCalculateMax()
        {
            // Arrange
            LoopyCalculator calc = new LoopyCalculator();

            // Act
            var max = calc.Max(Enumerable.Range(1, 10000).ToArray());

            // Assert
            Assert.AreEqual(10000, max);
        }
    }
}
