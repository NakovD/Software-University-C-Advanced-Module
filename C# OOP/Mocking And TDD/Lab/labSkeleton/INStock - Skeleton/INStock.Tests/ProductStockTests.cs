namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private ProductStock productStock;

        private Product product;

        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
            product = new Product("some product", 10, 10);
        }

        [Test]
        public void Test_AddMethodIncreasesCount()
        {
            productStock.Add(product);

            Assert.IsTrue(productStock.Count == 1);
            Assert.IsTrue(productStock.Contains(product));
        }

        [Test]
        public void Test_ContainsWorksCorrectly()
        {
            var productNotInStock = new Product("gosho", 10, 10);

            Assert.IsFalse(productStock.Contains(productNotInStock));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Test_FindThrowsWithNegativeIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(10)]
        public void Test_FindThrowsWithBiggerIndex(int index)
        {
            productStock.Add(new Product("some p", 10, 10));
            productStock.Add(new Product("some pa", 10, 10));
            productStock.Add(new Product("some pb", 10, 10));

            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        public void Test_FindsProductWithValidIndex()
        {
            var product = new Product("some p", 10, 10);

            productStock.Add(product);

            var foundProduct = productStock.Find(0);

            Assert.AreSame(product, foundProduct);
        }

        [Test]
        public void Test_FindAllByPriceReturnsEmptyCollectionWhenNoValidProducts()
        {
            productStock.Add(new Product("some p", 10, 10));
            productStock.Add(new Product("some pa", 10, 10));
            productStock.Add(new Product("some pb", 10, 10));

            var foundProducts = productStock.FindAllByPrice(11);

            CollectionAssert.IsEmpty(foundProducts);
        }

        [Test]
        public void Test_FindAllByPriceReturnsCorrectCollection()
        {
            var firstProduct = new Product("some p", 5, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 5, 10);

            var expectedResult = new List<IProduct>() { firstProduct, thirdProduct };

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actualResult = productStock.FindAllByPrice(5);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_FindAllByQuantityReturnsEmptyCollectionWhenNoValidProducts()
        {
            productStock.Add(new Product("some p", 10, 10));
            productStock.Add(new Product("some pa", 10, 10));
            productStock.Add(new Product("some pb", 10, 10));

            var foundProducts = productStock.FindAllByQuantity(11);

            CollectionAssert.IsEmpty(foundProducts);
        }

        [Test]
        public void Test_FindAllByQuantityReturnsCorrectCollection()
        {
            var firstProduct = new Product("some p", 10, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 10, 5);

            var expectedResult = new List<IProduct>() { firstProduct, secondProduct };

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actualResult = productStock.FindAllByQuantity(10);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10_000, 15_000)]
        [TestCase(15, 20)]
        [TestCase(-15_000, -10_000)]
        public void Test_FindAllInRangeReturnsEmptyCollectionWhenInvalidArgs(double low, double hi)
        {
            var firstProduct = new Product("some p", 10, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 10, 5);

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actualResult = productStock.FindAllInRange(low, hi);

            CollectionAssert.IsEmpty(actualResult);
        }

        [Test]
        [TestCase(5, 9)]
        [TestCase(5, 10)]
        [TestCase(6, 11)]
        [TestCase(5, 15)]
        public void Test_FindAllInRangeReturnsValidCollectionWithValidArgs(double low, double hi)
        {
            var firstProduct = new Product("some p", 5, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 15, 5);

            var products = new List<IProduct>() { firstProduct, secondProduct, thirdProduct };
            var expectedResult = products.Where(p => p.Price >= (decimal)low && p.Price <= (decimal)hi);

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actualResult = productStock.FindAllInRange(low, hi);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("some random label")]
        [TestCase("some random label2")]
        [TestCase("some random label3")]
        public void Test_FindByLabelThrowsWhenNoProductWithTheProvidedLabelIsFound(string label)
        {
            var firstProduct = new Product("some p", 10, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 10, 5);

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            Assert.Throws<ArgumentException>(() => productStock.FindByLabel(label));
        }

        [Test]
        public void Test_FindByLabelFindsCorrectProduct()
        {
            var firstProduct = new Product("some p", 10, 10);

            productStock.Add(firstProduct);

            var expectedResult = firstProduct;

            var actualResult = productStock.FindByLabel("some p");

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void Test_FindMostExpensiveProductReturnsCorrectProduct()
        {
            var firstProduct = new Product("some p", 5, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 15, 5);

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var expectedResult = thirdProduct;

            var actualResult = productStock.FindMostExpensiveProduct();

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void Test_RemoveRemovesCorrectItem()
        {
            var firstProduct = new Product("some p", 5, 10);
            var secondProduct = new Product("some pa", 10, 10);
            var thirdProduct = new Product("some pb", 15, 5);

            productStock.Add(firstProduct);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var expectedResult = secondProduct;

            var isRemoved = productStock.Remove(secondProduct);

            Assert.IsTrue(isRemoved);
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel(expectedResult.Label));
        }

        [Test]
        public void Test_RemoveRemovesDecreasesCount()
        {
            var product = new Product("some p", 5, 10);

            var expectedResult = 0;

            productStock.Add(product);

            productStock.Remove(product);

            var actualResult = productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
