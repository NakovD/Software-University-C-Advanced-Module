namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("make", "model", 3, 10);
        }

        [Test]
        public void Test_CarCtorThrowsWithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(string.Empty, "model", 10, 10);
            }, $"Car should throw if {car.Make} is empty string.");
        }

        [Test]
        public void Test_CarCtorThrowsWithNullMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(null, "model", 10, 10);
            }, $"Car should throw if {car.Make} is null.");
        }

        [Test]
        public void Test_CarCtorThrowsWithEmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "", 10, 10);
            }, $"Car should throw if {car.Model} is empty.");
        }

        [Test]
        public void Test_CarCtorThrowsWithNullModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", null, 10, 10);
            }, $"Car should throw if {nameof(car.Model)} is null.");
        }

        [Test]
        public void Test_CarCtorThrowsWithZeroFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", 0, 10);
            }, $"Car should throw if {car.FuelConsumption} is 0.");
        }

        [Test]
        public void Test_CarCtorThrowsWithNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", -50, 10);
            }, $"Car should throw if {car.FuelConsumption} is negative.");
        }

        [Test]
        public void Test_CarCtorThrowsWithZeroFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", 10, 0);
            }, $"Car should throw if {car.FuelCapacity} is 0.");
        }

        [Test]
        public void Test_CarCtorThrowsWithNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", 10, -50);
            }, $"Car should throw if {car.FuelCapacity} is negative.");
        }

        [Test]
        public void Test_CarCtorCreatesCarWithValidParameters()
        {
            Assert.DoesNotThrow(() =>
            {
                car = new Car("some make", "some model", 10.3, 3.4);
            }, "Car ctor throws with valid arguments.");
        }

        [Test]
        public void Test_CarRefuelMethodThrowsWithZeroRefuelFuel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Car refuel method doesn't throw when receives 0 refuel fuel.");
        }

        [Test]
        public void Test_CarRefuelMethodThrowsWithNegativeRefuelFuel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-50);
            }, "Car refuel method doesn't throw when receives negative refuel fuel.");
        }

        [Test]
        public void Test_CarRefuelMethodRefuelsTheCarFuelWithZeroFuel()
        {
            var amountToRefuel = 5;
            car.Refuel(amountToRefuel);

            Assert.IsTrue(car.FuelAmount == amountToRefuel, "With zero fuel, car doesn't refuel with correct amount.");
        }

        [Test]
        public void Test_CarRefuelMethodRefuelsTheCarFuelWithSomeFuel()
        {
            var baseFuel = 3;
            var newFuel = 5;

            car.Refuel(baseFuel);
            car.Refuel(newFuel);

            Assert.IsTrue(car.FuelAmount == baseFuel + newFuel, "Car doesn't add up already existing fuel with the new amount.");
        }

        [Test]
        public void Test_CarRefuelMethodRefuelsAndLimitsTheFuelToTheCarCapacity()
        {
            var newFuel = 10_000;

            car.Refuel(newFuel);

            Assert.True(car.FuelAmount == car.FuelCapacity, "Car refuel method doesn't limit the new fuel to the car fuel capacity.");
        }

        [Test]
        public void Test_CarDriveMethodThrowsIfTheFuelForTheDriveIsMoreThanCurrentFuelAmount()
        {
            var distance = 10_000;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "Car drive method doesn't throw when fuel needed for the trip is more than the current fuel amount.");
        }

        [Test]
        public void Test_CarDriveMethodReducesTheFuelAmountAfterSuccessfullDrive()
        {
            car.Refuel(10);

            double fuelBeforeDrive = car.FuelAmount;

            double distance = 2;

            car.Drive(distance);

            double carFuelConsumption = car.FuelConsumption;

            double fuelAfterDrive = car.FuelAmount;

            double neededFuelForDrive = (distance / 100) * carFuelConsumption;

            var message = "Car drive method doesn't work correctly.";

            Assert.AreNotEqual(fuelBeforeDrive, fuelAfterDrive, message);

            Assert.IsTrue(fuelBeforeDrive - neededFuelForDrive == fuelAfterDrive, message);
        }
    }
}