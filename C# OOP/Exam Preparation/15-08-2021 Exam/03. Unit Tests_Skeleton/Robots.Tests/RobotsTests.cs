namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("robocop", 15);
            robotManager = new RobotManager(10);
        }

        [Test]
        [TestCase("gosho", 10)]
        [TestCase("tosho", 100)]
        [TestCase("pesho", 1000)]
        public void RobotCtorSetsRobotPropertiesCorrectly(string name, int maximumBattery)
        {
            var expectedName = name;
            var expectedMaximumBattery = maximumBattery;
            var expectedBattery = maximumBattery;

            robot = new Robot(name, maximumBattery);

            var actualName = robot.Name;
            var actualMaximumBattery = robot.MaximumBattery;
            var actualBattery = robot.Battery;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedMaximumBattery == actualMaximumBattery);
            Assert.IsTrue(expectedBattery == actualBattery);
        }

        [Test]
        [TestCase("penko", 10)]
        [TestCase("tonko", 50)]
        public void RobotNameAndBatteryAreChangedCorrectly(string name, int battery)
        {
            var expectedName = name;
            var expectedBattery = battery;

            robot.Name = name;
            robot.Battery = battery;

            var actualName = robot.Name;
            var actualBattery = robot.Battery;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedBattery == actualBattery);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void RobotManagerCtorThrowsWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(capacity));
        }

        [Test]
        public void RobotManagerCtorCreatesTheManagerCorrectly()
        {
            var expectedCount = 0;
            var expectedCapacity = 15;

            robotManager = new RobotManager(expectedCapacity);

            var actualCount = robotManager.Count;
            var actualCapacity = robotManager.Capacity;

            Assert.IsTrue(expectedCount == actualCount);
            Assert.IsTrue(expectedCapacity == actualCapacity);
        }

        [Test]
        public void AddMethodThrowsIfThereIsRobotWithTheSameName()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddMethodThrowsIfTheCapacityIsReached()
        {
            robotManager = new RobotManager(1);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddMethodIncreasesTheCountOfTheRobots()
        {
            //maybe use reflection to check the collection?
            var expectedCount = 1;

            robotManager.Add(robot);

            var actualCount = robotManager.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void RemoveMethodThrowsWithRobotWithNameThatDoesntExist()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("gosho"));
        }

        [Test]
        public void RemoveReducesTheCountOfTheRobotsAfterRemoving()
        {
            //maybe use reflection;
            var expectedCount = 0;

            robotManager.Add(robot);
            robotManager.Remove(robot.Name);

            var actualCount = robotManager.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void WorkThrowsWithNameOfRobotThatDoesntExist()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("gpsho", "ga", 1));
        }

        [Test]
        public void WorkThrowsWithBatteryUsageBiggerThanTheRobotCurrentBattery()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "dada", 20));
        }

        [Test]
        public void WorkReducesTheRobotBattery()
        {
            var batteryUsage = 5;

            var expectedResult = robot.Battery - batteryUsage;

            robotManager.Add(robot);
            robotManager.Work(robot.Name, "gosho", batteryUsage);

            var actualResult = robot.Battery;

            Assert.IsTrue(expectedResult == actualResult);
        }

        [Test]
        public void ChargeThrowsWithNameOfRobotThatDoesntExist()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("gpsho"));
        }

        [Test]
        public void ChargeMethodChargesTheRobotToTheMaximumBattery()
        {
            var expectedResult = robot.MaximumBattery;

            robotManager.Add(robot);
            robotManager.Work(robot.Name, "gosho", 10);
            robotManager.Charge(robot.Name);

            var actualResult = robot.Battery;

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}
