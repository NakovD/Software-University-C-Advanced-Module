using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;

            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car("BMW", 3);
                garage = new Garage("Garage", 2);
            }


            [Test]
            [TestCase("Some Model", 5)]
            [TestCase("Some Model", 1)]
            [TestCase("Some Model", 0)]
            public void CarCtorSetsThePassedArgs(string carModel, int numberOfIssues)
            {
                var expectedModel = carModel;
                var expectedIssues = numberOfIssues;
                var expectedIsFixed = numberOfIssues == 0;

                var car = new Car(carModel, numberOfIssues);

                var actualModel = car.CarModel;
                var actualIssues = car.NumberOfIssues;
                var actualIsFixed = car.IsFixed;

                Assert.IsTrue(expectedModel == actualModel);
                Assert.IsTrue(expectedIssues == actualIssues);
                Assert.IsTrue(expectedIsFixed == actualIsFixed);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void GarageCtorThrowsWithInvalidName(string name)
            {
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(name, 0));
            }

            [Test]
            [TestCase(0)]
            [TestCase(-5)]
            [TestCase(-50)]
            public void GarageCtorThrowsWithInvalidMechanics(int mechs)
            {
                Assert.Throws<ArgumentException>(() => garage = new Garage("Garage", mechs));

            }

            [Test]
            [TestCase("garage", 5)]
            [TestCase("garage2", 50)]
            [TestCase("garage3", 1)]
            public void GarageCtorSetsThePassedArgs(string name, int mechs)
            {
                var expectedName = name;
                var expectedMechs = mechs;
                var expectedCarsCount = 0;

                garage = new Garage(name, mechs);

                var actualName = garage.Name;
                var actualMechs = garage.MechanicsAvailable;
                var actualCarsCount = garage.CarsInGarage;

                Assert.IsTrue(expectedName == actualName);
                Assert.IsTrue(expectedMechs == actualMechs);
                Assert.IsTrue(expectedCarsCount == actualCarsCount);
            }

            [Test]
            public void AddMethodThrowsIfCarsCountIsEqualToMechsAvailable()
            {
                var car = new Car("car", 1);
                var car1 = new Car("car1", 2);

                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));
            }

            [Test]
            public void AddMethodAddsCarInTheGarage()
            {
                garage.AddCar(car);

                var expectedCarsCount = 1;

                var actualCarsCount = garage.CarsInGarage;

                Assert.IsTrue(expectedCarsCount == actualCarsCount);
            }

            [Test]
            public void FixCarThrowsWhenTryingToFixNonExistentCar()
            {
                var car = new Car("car", 2);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("car1"));
            }

            [Test]
            public void FixCarFixesTheCarIssues()
            {
                var expectedResult = car;

                garage.AddCar(car);

                var actualResult = garage.FixCar(car.CarModel);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.IsTrue(expectedResult.NumberOfIssues == actualResult.NumberOfIssues);
            }


            [Test]
            public void RemoveFixCarThrowsIfThereArentFixedCars()
            {
                var car = new Car("car", 5);
                var car1 = new Car("car1", 5);

                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }

            [Test]
            public void RemoveFixCarRemovesFixedCars()
            {
                var newCar = new Car("tata", 5);

                garage.AddCar(car);
                garage.AddCar(newCar);

                garage.FixCar(car.CarModel);

                var expectedCarsAmountAfterRemove = 1;

                var expectedAmountFixedCars = 1;

                var actualAmountFixed = garage.RemoveFixedCar();

                var actualCarsAmountAfterRemove = garage.CarsInGarage;

                Assert.IsTrue(expectedCarsAmountAfterRemove == actualAmountFixed);
                Assert.IsTrue(expectedAmountFixedCars == actualAmountFixed);
            }

            [Test]
            public void ReportReturnsCorrectReport()
            {
                var newCar = new Car("Gosho", 3);
                var expectedResult = $"There are {2} which are not fixed: {car.CarModel + ", " + newCar.CarModel}.";

                garage.AddCar(car);
                garage.AddCar(newCar);
                
                var actualResult = garage.Report();

                Assert.IsTrue(expectedResult == actualResult);
            }
        }
    }
}