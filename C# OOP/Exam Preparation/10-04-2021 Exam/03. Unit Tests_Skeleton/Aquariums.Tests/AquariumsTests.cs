namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;

        private Aquarium aquarium;

        [SetUp]

        public void SetUp()
        {
            fish = new Fish("gosho");
            aquarium = new Aquarium("Some aqua", 10);
        }

        [Test]
        public void FishCtorSetsThePropertiesCorrectly()
        {
            var expectedName = "Gosho";
            var expectedAvailable = true;

            fish = new Fish(expectedName);

            var actualName = fish.Name;
            var actualAvailable = fish.Available;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedAvailable == actualAvailable);
        }

        [Test]
        public void FishPropertiesCanBeChanged()
        {
            var expectedName = "Tosho";
            var expectedAvailable = false;

            fish = new Fish("Gosho");

            fish.Name = expectedName;
            fish.Available = expectedAvailable;

            var actualName = fish.Name;
            var actualAvailable = fish.Available;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedAvailable == actualAvailable);
        }

        [Test]
        public void AquariumCtorThrowsWithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("some name", -3));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumCtorThrowsWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, 10));
        }

        [Test]
        public void AquariumCtorSetsThePropetiesCorrectly()
        {
            var expectedName = "Som aqua";
            var expectedCapacity = 10;
            var expectedCount = 0;

            aquarium = new Aquarium(expectedName, expectedCapacity);

            var actualName = "Som aqua";
            var actualCapacity = 10;
            var actualCount = 0;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedCapacity == actualCapacity);
            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void AddMethodThrowsIfCapacityIsReached()
        {
            aquarium = new Aquarium("bazigna", 2);
            aquarium.Add(new Fish("gosho"));
            aquarium.Add(new Fish("tosho"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("pesho")));
        }

        [Test]
        public void AddMethodIncreasesTheFishCount()
        {
            var expectedCount = 2;

            aquarium.Add(fish);
            aquarium.Add(new Fish("gosho"));

            var actualCount = aquarium.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void CountReturnsCorrectNumberOfFishes()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish);

            var expectedCount = 3;

            var actualCOunt = aquarium.Count;

            Assert.IsTrue(expectedCount == actualCOunt);
        }

        [Test]
        public void RemoveMethodThrowsWithInvalidFishName()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fish.Name));
        }

        [Test]
        public void RemoveMethodReducesTheFishCount()
        {
            var expectedCount = 1;

            aquarium.Add(new Fish("gosho"));
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);

            var actualCount = aquarium.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void SellFishThrowsWithInvalidFishName()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fish.Name));
        }

        [Test]
        public void SellFishMakesTheFishUnAvailable()
        {
            aquarium.Add(fish);
            var _fish = aquarium.SellFish(fish.Name);

            var result = fish.Available;
            

            Assert.IsFalse(result);
            Assert.AreEqual(fish, _fish);
        }

        [Test]
        public void ReportReturnsStringWithNoFishNamesWithNoFishes()
        {
            var fishNames = string.Join(", ", new List<Fish>());
            var expectedResult = $"Fish available at {aquarium.Name}: {fishNames}";

            var actualResult = aquarium.Report();

            Assert.IsTrue(expectedResult == actualResult);
        }

        [Test]
        public void ReportReturnsCorrectStringWithFewFishes()
        {
            var firstFishName = "tosho";
            var secondFishName = "pesho";
            var thirdFishName = fish.Name;
            var fishes = new List<Fish>()
            {
                new Fish(firstFishName),
                new Fish(secondFishName),
                fish
            };

            aquarium.Add(fishes[0]);
            aquarium.Add(fishes[1]);
            aquarium.Add(fishes[2]);

            var fishNames = string.Join(", ", fishes.Select(f => f.Name));

            var expectedResult = $"Fish available at {aquarium.Name}: {fishNames}";
                
            var actualResult = aquarium.Report();

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}
