using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;

            private Planet planet;

            [Test]
            [TestCase("Gosho", -1, 10)]
            [TestCase("Gosho", -50, 10)]
            [TestCase("Gosho", -500, 10)]
            public void WeaponCtorThrowsWithInvalidValues(string name, double price, int destructionLevel)
            {
                Assert.Throws<ArgumentException>(() => weapon = new Weapon(name, price, destructionLevel));
            }

            [Test]
            [TestCase("Gosho", 10, 10)]
            [TestCase("Pesjko", 100, 5)]
            [TestCase("Tonio", 1000, 500)]
            public void WeaponCtorWorksWithCorrectValues(string name, double price, int destructionLevel)
            {
                weapon = new Weapon(name, price, destructionLevel);

                Assert.IsTrue(name == weapon.Name);
                Assert.IsTrue(price == weapon.Price);
                Assert.IsTrue(destructionLevel == weapon.DestructionLevel);
            }


            [Test]
            [TestCase(10, 11)]
            [TestCase(100, 101)]
            [TestCase(5000, 5001)]
            public void IncreaseDestructionLevelIncreasesTheDesctructionLevel(int descLeve, int expectedResult)
            {
                weapon = new Weapon("gosho", 10, descLeve);

                weapon.IncreaseDestructionLevel();

                Assert.IsTrue(weapon.DestructionLevel == expectedResult);
            }

            [Test]
            [TestCase(9, false)]
            [TestCase(10, true)]
            [TestCase(100, true)]
            public void IsNuclearReturnsCorrectStateOfTheWeapon(int desctructionLevel, bool expectedResult)
            {
                weapon = new Weapon("Gosho", 10, desctructionLevel);

                Assert.IsTrue(weapon.IsNuclear == expectedResult);
            }

            [Test]
            [TestCase(null, 10)]
            [TestCase("", 10)]
            [TestCase("Gosho", -5)]
            [TestCase("Gosho", -50)]
            public void PlanetCtorThrowsWithInvalidArgs(string name, double budget)
            {
                Assert.Throws<ArgumentException>(() => planet = new Planet(name, budget));
            }

            [Test]
            [TestCase("Gosho", 0)]
            [TestCase("Gosho", 100)]
            public void PlanetCtorWorksWithCorrectArgs(string name, double budget)
            {
                planet = new Planet(name, budget);

                Assert.IsTrue(planet.Name == name);
                Assert.IsTrue(planet.Budget == budget);
                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>());
            }

            [Test]
            public void PlanetMilitaryPowerRatioSumCorrectly()
            {
                var weapon = new Weapon("gosho", 100, 100);
                var weapon2 = new Weapon("gosho1", 100, 150);
                var weapon3 = new Weapon("gosho2", 100, 200);

                var weapons = new List<Weapon>() {
                    weapon, weapon2, weapon3
                };

                planet = new Planet("gosho", 100);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                var expectedResult = weapons.Sum(weapon => weapon.DestructionLevel);

                var actualResult = planet.MilitaryPowerRatio;

                Assert.IsTrue(expectedResult == actualResult);
            }

            [Test]
            [TestCase(5)]
            [TestCase(100)]
            [TestCase(5000)]
            public void ProfitMethodCorrectlyIncreasesTheBudget(double amount)
            {
                planet = new Planet("gosho", 100);

                var planetInitialBudget = planet.Budget;

                planet.Profit(amount);

                var expected = planetInitialBudget + amount;

                var actual = planet.Budget;

                Assert.IsTrue(expected == actual);
            }

            [Test]
            [TestCase(101)]
            [TestCase(600)]
            [TestCase(6000)]
            public void SpendFundsThrowsIfGivenAmountIsBiggerThanThebudget(double decreaseAmount)
            {
                planet = new Planet("gosho", 100);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(decreaseAmount));
            }

            [Test]
            [TestCase(101)]
            [TestCase(1000)]
            public void SpendFundsDecreasesTheBudgetCorrectly(double decreaseAmount)
            {
                planet = new Planet("gosho", 1000);

                var expected = planet.Budget - decreaseAmount;

                planet.SpendFunds(decreaseAmount);

                var actual = planet.Budget;

                Assert.IsTrue(expected == actual);
            }

            [Test]
            public void AddWeaponThrowsWithAlreadyExistingWeapon()
            {
                weapon = new Weapon("gosho", 10, 10);

                planet = new Planet("tosho", 100);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void AddWeaponAddCorrectlyTheNewWeapon()
            {
                weapon = new Weapon("gosho", 10, 10);

                planet = new Planet("tosho", 100);

                var weaponsCountBeforeAdd = planet.Weapons.Count;

                planet.AddWeapon(weapon);

                var weapons = planet.Weapons;

                Assert.IsTrue(weaponsCountBeforeAdd + 1 == planet.Weapons.Count);
                CollectionAssert.AreEqual(weapons, new List<Weapon>() { weapon });
            }

            [Test]
            public void RemoveWeaponRemovesWeaponCorrectly()
            {
                weapon = new Weapon("gosho", 100, 100);

                planet = new Planet("gosho", 1000);

                planet.AddWeapon(weapon);

                var countBeforeRemoving = planet.Weapons.Count;

                planet.RemoveWeapon(weapon.Name);

                var weapons = new List<Weapon>();

                Assert.IsTrue(weapons.Count + 1 == countBeforeRemoving);

                CollectionAssert.AreEqual(weapons, planet.Weapons);
            }

            [Test]
            [TestCase("tanio")]
            [TestCase("dada")]
            [TestCase("gogo")]
            public void UpgradeWeaponThrowsWhenWeaponIsNotFound(string name)
            {
                var weapon = new Weapon("gosho", 100, 100);
                var weapon1 = new Weapon("gosho1", 100, 100);
                var weapon2 = new Weapon("gosho2", 100, 100);

                planet = new Planet("gpsjp", 100);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => { planet.UpgradeWeapon(name); });
            }

            [Test]
            public void UpgradeWeaponCorrectlyUpgradesWeapon()
            {
                var weapon = new Weapon("gosho", 100, 100);

                planet = new Planet("gpsjp", 100);

                planet.AddWeapon(weapon);

                var desctructionLevelBeforeIncrease = weapon.DestructionLevel;

                planet.UpgradeWeapon("gosho");

                Assert.IsTrue(desctructionLevelBeforeIncrease + 1 == weapon.DestructionLevel);
            }

            [Test]
            public void DesctructOpponentThrowsIfTheCurrentPlanetPowerIsTooLow()
            {
                var firstPlanet = new Planet("gosho", 1000);

                var weapon = new Weapon("gosho", 100, 100);
                var weapon2 = new Weapon("gosho1", 100, 150);
                var weapon3 = new Weapon("gosho2", 100, 200);

                var weapons = new List<Weapon>() {
                    weapon, weapon2, weapon3
                };

                var secondPlanet = new Planet("gosho", 100);
                secondPlanet.AddWeapon(weapon);
                secondPlanet.AddWeapon(weapon2);
                secondPlanet.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() => firstPlanet.DestructOpponent(secondPlanet));
            }

            [Test]
            public void DesctructOpponentWorksCorrectly()
            {
                var firstPlanet = new Planet("gosho", 1000);

                var weapon = new Weapon("gosho", 100, 100);
                var weapon2 = new Weapon("gosho1", 100, 150);
                var weapon3 = new Weapon("gosho2", 100, 200);

                var weapons = new List<Weapon>() {
                    weapon, weapon2, weapon3
                };

                firstPlanet.AddWeapon(weapon);
                firstPlanet.AddWeapon(weapon2);
                firstPlanet.AddWeapon(weapon3);

                var secondPlanet = new Planet("gosho", 100);
                var expected = $"{secondPlanet.Name} is destructed!";
                var result = firstPlanet.DestructOpponent(secondPlanet);

                Assert.IsTrue(expected == result);
            }
        }
    }
}
