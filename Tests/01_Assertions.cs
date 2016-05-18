using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Assertions
    {
        [Test]
        public void Assert_Singular()
        {
            var ages = new[] { 99, 36, 37 };

            Assert.AreEqual(35, ages[0]);
        }

        [Test]
        public void Assert_AreSimilar()
        {
            var cheeses = new[] { "Brie", "Blue mould", "Cheddar" };

            CollectionAssert.AreEquivalent(new[] { "Cheddar", "Stilton", "Brie" }, cheeses);
        }

        [Test]
        public void Assert_AreSameOrder()
        {
            var distancesAscending = new[] { 2.5, 1.2, 15.0 };

            CollectionAssert.AreEqual(new [] { 1.2, 2.5, 15.0 }, distancesAscending);
        }

    }
}
