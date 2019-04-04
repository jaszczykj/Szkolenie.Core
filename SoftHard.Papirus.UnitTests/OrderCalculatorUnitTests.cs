using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftHard.Papirus.IServices;
using System;

namespace SoftHard.Papirus.UnitTests
{
    [TestClass]
    public class OrderCalculatorUnitTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidTest()
        {
            IOrderCalculator orderCalculator = new MyOrderCalculator();

            Location location = null;

            decimal amount = 100;

            // Acts

            decimal result = orderCalculator.Calculate(location, amount);

        }

        [TestMethod]
        public void CalculateTest()
        {
            // Arrange
            IOrderCalculator orderCalculator = new MyOrderCalculator();

            Location location = new Location { Latitude = 150, Longitude = 50 };
            decimal amount = 100;

            // Acts

            decimal result = orderCalculator.Calculate(location, amount);

            // Asserts

            Assert.AreEqual(200, result, "nierowny");
            Assert.IsTrue(result > 0, "wartosci wieksza od 0");


        }
    }
}
