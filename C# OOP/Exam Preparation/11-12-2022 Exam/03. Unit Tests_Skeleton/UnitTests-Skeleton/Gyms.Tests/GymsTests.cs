using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;

        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Tonko");
            gym = new Gym("Poro", 10);
        }

        [Test]
        [TestCase("Gosho")]
        [TestCase("Tosho")]
        [TestCase("Posho")]
        public void AthleteCreatesObjectWithValidArgs(string fullName)
        {
            var expectedFullName = fullName;
            var expectedIsInjured = false;

            athlete = new Athlete(fullName);

            var actualFullName = athlete.FullName;
            var actualIsInjured = athlete.IsInjured;

            Assert.IsTrue(expectedFullName == actualFullName);
            Assert.IsTrue(expectedIsInjured == actualIsInjured);
        }

        [Test]
        [TestCase(null, 1)]
        [TestCase("", 1)]
        public void GymCtorThrowsWithInvalidName(string name, int size)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, size));
        }

        [Test]
        [TestCase("SomGym", -5)]
        [TestCase("MonGym", -50)]
        public void GymCtorThrowsWithNegativeCapacity(string name, int size)
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym(name, size));

        }

        [Test]
        [TestCase("somGym", 10)]
        [TestCase("GonGym", 50)]
        public void GymCtorCreatesGymWithValidArgs(string name,int size)
        {
            var expectedName = name;
            var expectedSize = size;
            var expectedCount = 0;

            gym = new Gym(name, size);

            var actualName = gym.Name;
            var actualSize = gym.Capacity;
            var actualCount = gym.Count;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedSize == actualSize);
            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void AddAthleteThrowsIfTheAthleteCountIsEqualToTheCapacityWithZeroCapacity()
        {
            gym = new Gym("Gosho", 0);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void AddAthleteThrowsIfTheAthleteCountIsEqualToTheCapacity()
        {
            gym = new Gym("toar", 2);

            gym.AddAthlete(new Athlete("Penko"));
            gym.AddAthlete(new Athlete("tosho"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void AddAthleteIncreasesTheGymCountWithNoAthletes()
        {
            var expectedCount = 1;

            gym.AddAthlete(athlete);

            var actualCount = gym.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void AddAthleteIncreasesTheGymCountWithSomeAthletes()
        {
            var expectedCount = 3;

            gym.AddAthlete(new Athlete("gogoo"));
            gym.AddAthlete(new Athlete("dodo"));
            gym.AddAthlete(athlete);

            var actualCount = gym.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void RemoveAthleteThrowsWithNonExistentAthlete()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("got"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("gogo"));
        }

        [Test]
        public void RemoveAthleteReducesTheGymCount()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("got"));

            var expectedCount = 1;

            gym.RemoveAthlete(athlete.FullName);

            var actualCount = gym.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void InhureAthleteThrowsWithnonExistentAthlete()
        {
            gym.AddAthlete(new Athlete("toto"));
            gym.AddAthlete(new Athlete("gogo"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(athlete.FullName));
        }

        [Test]
        public void InjureAthleteInjuresTheAthlete()
        {
            gym.AddAthlete(new Athlete("toro"));
            gym.AddAthlete(new Athlete("googo"));
            gym.AddAthlete(athlete);

            var expectedIsInjured = !athlete.IsInjured;

            var actualIsInjured = gym.InjureAthlete(athlete.FullName).IsInjured;

            Assert.IsTrue(expectedIsInjured == actualIsInjured);
        }

        [Test]
        public void ReportReturnsNonInjuredAthletes()
        {
            var sAthlete = new Athlete("gosho");
            var tAthlete = new Athlete("gogo");
            var fAthlete = new Athlete("tosho");
            fAthlete.IsInjured = true;

            var athletes = new List<Athlete>()
            {
                athlete,
                sAthlete,
                tAthlete,
                fAthlete
            };

            gym.AddAthlete(athlete);
            gym.AddAthlete(sAthlete);
            gym.AddAthlete(tAthlete);
            gym.AddAthlete(fAthlete);

            var athletesNames = string.Join(", ", athletes.Where(a => !a.IsInjured).Select(a => a.FullName));
            var expectedReport = $"Active athletes at {gym.Name}: {athletesNames}";

            var actualReport = gym.Report();

            Assert.IsTrue(expectedReport == actualReport);
        }

        [Test]
        public void ReportReturnsCorrectStringWithNoAthletes()
        {
            var atheleteNames = string.Join(", ", new List<Athlete>());
            var expectedReport = $"Active athletes at {gym.Name}: {atheleteNames}";

            var actualReport = gym.Report();

            Assert.IsTrue(expectedReport == actualReport);
        }
    }
}
