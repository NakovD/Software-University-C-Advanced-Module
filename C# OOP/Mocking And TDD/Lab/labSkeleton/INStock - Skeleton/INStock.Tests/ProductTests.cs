namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        private Product product;

        [Test]
        [TestCase(null, 10, 10)]
        [TestCase("", 10, 10)]
        [TestCase(" ", 10, 10)]
        [TestCase("Test product", 0, 10)]
        [TestCase("Test product", -5, 10)]
        [TestCase("Test product", -50, 10)]
        public void Test_ProductCtorThrowsWithInvalidArgs(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => product = new Product(label, price, quantity));
        }

        [Test]
        public void Test_ProductCtorCreatesProductWithValidArgs()
        {
            var expectedLabel = "Test product";
            var expectedPrice = 5.5M;
            var expectedQuantity = 10;

            product = new Product(expectedLabel, expectedPrice, expectedQuantity);

            Assert.IsTrue(expectedLabel == product.Label);
            Assert.IsTrue(expectedPrice == product.Price);
            Assert.IsTrue(expectedQuantity == product.Quantity);
        }

        [Test]
        [TestCase("aproduct", "bproduct", -1)]
        [TestCase("bproduct", "aproduct", 1)]
        [TestCase("aproduct", "aproduct", 0)]
        public void Test_ProductCompareToWorksProperly(string firstProductName, string secondProductName, int expectedResult)
        {
            var product = new Product(firstProductName, 10, 10);
            var anotherProduct = new Product(secondProductName, 10, 10);

            var actualResult = product.CompareTo(anotherProduct);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}