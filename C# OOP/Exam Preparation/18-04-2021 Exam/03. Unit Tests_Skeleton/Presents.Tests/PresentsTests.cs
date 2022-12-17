namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;

        private Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
            present = new Present("some present", 10);
        }

        [Test]
        [TestCase("some name", 50)]
        [TestCase("somed", 50.3)]
        [TestCase("some1ame", 100.3)]
        public void PresentCtorSetsThePropertiesCorrectly(string name, double magic)
        {
            var expectedName = name;
            var expectedMagic = magic;

            present = new Present(name, magic);

            var actualName = present.Name;
            var actualMagic = present.Magic;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedMagic == actualMagic);
        }

        [Test]
        [TestCase("some name", 50)]
        [TestCase("some na313me", 120)]
        [TestCase("some", 1)]
        public void PresentPropertiesCanBeChanged(string name, double magic)
        {
            var expectedName = name;
            var expectedMagic = magic;

            present = new Present("some name", 20);

            present.Name = expectedName;
            present.Magic = expectedMagic;

            var actualName = present.Name;
            var actualMagic = present.Magic;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedMagic == actualMagic);
        }

        [Test]
        public void BagCtorCreatesEmptyCollection()
        {
            var expectedCollection = new List<Present>().AsReadOnly();

            var actualCollection = bag.GetPresents();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void CreateThrowsIfPassedPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateThrowsWithPassedArgumentsOfPresentAlreadyInTheBag()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateAddsThePresentToTheCollection()
        {
            var expectedCollection = new List<Present>() { present }.AsReadOnly();
            var expectedResult = $"Successfully added present {present.Name}.";
            var expectedCount = expectedCollection.Count;

            var actualCollection = bag.GetPresents();
            var actualResult = bag.Create(present);
            var actualCount = actualCollection.Count;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.IsTrue(expectedResult == actualResult);
            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void RemoveReturnsFalseWithNonExistingPresent()
        {
            var actualResult = bag.Remove(present);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void RemoveRemovesThePresentFromTheCollection()
        {
            var expectedResult = true;
            var expectedCollection = new List<Present>().AsReadOnly();
            var expectedCount = expectedCollection.Count;

            bag.Create(present);

            var actualResult = bag.Remove(present);
            var actualCollection = bag.GetPresents();
            var actualCount = actualCollection.Count;

            Assert.IsTrue(expectedResult == actualResult);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void GetPresentWithLeastMagicReturnsCorrectPresent()
        {
            var expectedResult = present;

            bag.Create(present);
            bag.Create(new Present("some e", 1000));
            bag.Create(new Present("some dae", 5131));

            var actualResult = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetPresentReturnsNullWithNonExistingPresent()
        {
            var actualResult = bag.GetPresent("dawdawd");

            Assert.IsNull(actualResult);
        }

        [Test]
        public void GetPresentReturnsCorrectPresent()
        {
            var expectedResult = present;

            bag.Create(present);
            bag.Create(new Present("dada", 100));
            
            var actualResult = bag.GetPresent(present.Name);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
