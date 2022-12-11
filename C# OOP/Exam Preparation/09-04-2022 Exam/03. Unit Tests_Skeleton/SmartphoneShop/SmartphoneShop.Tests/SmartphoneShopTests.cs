using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;

        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone("Nokia", 10);
            shop = new Shop(50);
        }

        [Test]
        [TestCase("some model", 10)]
        [TestCase("some model1", 100)]
        [TestCase("some model2", 50)]
        public void SmartphoneCtorSetsPropsCorrectly(string modelName, int maximumBatteryCharge)
        {
            var expectedModelName = modelName;
            var expectedMaxBatteryCharge = maximumBatteryCharge;
            var expectedCurrentBateryCharge = maximumBatteryCharge;

            var smartPhone = new Smartphone(modelName, maximumBatteryCharge);

            var actualModelName = smartPhone.ModelName;
            var actualMaxBatteryCharge = smartPhone.MaximumBatteryCharge;
            var actualCurrentBateryCharge = smartPhone.CurrentBateryCharge;

            Assert.IsTrue(expectedModelName == actualModelName);
            Assert.IsTrue(expectedMaxBatteryCharge == actualMaxBatteryCharge);
            Assert.IsTrue(expectedCurrentBateryCharge == actualCurrentBateryCharge);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-50)]
        public void ShopCtorThrowsWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(capacity));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(50)]
        public void ShopCtorSetsPropsCorrectly(int capacity)
        {
            var expectedCapacity = capacity;
            var expectedCount = 0;

            shop = new Shop(capacity);

            var actualCapacity = shop.Capacity;
            var actualCount = shop.Count;

            Assert.IsTrue(expectedCapacity == actualCapacity);
            Assert.IsTrue(expectedCount== actualCount);
        }

        [Test]
        public void AddThrowsWhenAddingExistingPhone() 
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddThrowsWhenReachedTheCapacity()
        {
            shop = new Shop(1);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddAddsThePhoneWhenItsNotExisting()
        {
            var expectedCount = 1;

            shop.Add(smartphone);

            var actualCount = shop.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void RemoveThrowsWhenTryingToRemoveNonExistentPhone()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove(smartphone.ModelName));
        }

        [Test]
        public void RemoveRemovesAndReducesTheCountOfThePhones()
        {
            shop.Add(smartphone);
            var expectedCount = 0;

            shop.Remove(smartphone.ModelName);

            var actualCount = shop.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void TestPhoneThrowsWithInvalidPhone()
        {
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, 5));
        }

        [Test]
        [TestCase(15)]
        [TestCase(50)]
        public void TestPhoneThrowsWithBatterUsageBiggerThanThePhoneCurrentBattery(int batterUsage)
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, batterUsage));
        }

        [Test]
        [TestCase(5)]
        [TestCase(9)]
        [TestCase(2)]
        public void TestPhoneReducesTheBatteryOfThePhoneCorrectly(int batteryUsage)
        {
            shop.Add(smartphone);

            var expected = smartphone.CurrentBateryCharge - batteryUsage;

            shop.TestPhone(smartphone.ModelName, batteryUsage);

            var actual = smartphone.CurrentBateryCharge;

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void ChargePhoneThrowsWithNonExistentPhone()
        {
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone(smartphone.ModelName));
        }

        [Test]
        public void ChargePhoneChargesThePhoneToTheMax()
        {
            shop.Add(smartphone);

            shop.TestPhone(smartphone.ModelName, 5);

            var expected = smartphone.MaximumBatteryCharge;

            shop.ChargePhone(smartphone.ModelName);

            var actual = smartphone.CurrentBateryCharge;

            Assert.IsTrue(expected == actual);
        }
    }
}