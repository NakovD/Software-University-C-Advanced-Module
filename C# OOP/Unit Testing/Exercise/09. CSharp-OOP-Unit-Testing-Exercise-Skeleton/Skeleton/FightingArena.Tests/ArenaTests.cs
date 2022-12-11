namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior = new Warrior("David", 100, 100);
        }

        [Test]
        public void Test_ArenaCtorCreatesWarriosCollection()
        {
            var message = "Arena ctor doesn't create the warriors collection correctly.";

            Assert.AreEqual(arena.Warriors, new List<Warrior>(), message);
            Assert.IsTrue(arena.Count == 0, message);
        }

        [Test]
        public void Test_ArenaCtorCreatesWarriosReadonlyCollection()
        {
            Assert.True(arena.Warriors is IReadOnlyCollection<Warrior>);
        }

        [Test]
        public void Test_EnrollMethodThrowsWhenAddingAlreadyEnrolledWarrior()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Enroll method doesn't throw when adding already enrolled warrior.");
        }

        [Test]
        public void Test_EnrollMethodUpdatesWarriosCorrectly()
        {
            var testList = new List<Warrior>() { warrior };
            arena.Enroll(warrior);

            Assert.AreEqual(arena.Warriors, testList);
        }

        [Test]
        public void Test_EnrollMethodIncreasesWarriosCount()
        {
            var previousWarriorsCount = arena.Count;

            arena.Enroll(warrior);

            Assert.IsTrue(arena.Count == previousWarriorsCount + 1, "Enroll method doesn't increase the warriors count correctly.");
        }

        [Test]
        public void Test_FightMethodThrowsWhenAttackerIsNotEnrolled()
        {
            arena.Enroll(warrior);

            var notEnrolledWarrior = new Warrior("tonko", 10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(notEnrolledWarrior.Name, warrior.Name);

            }, "Fight method doesn't throw when attacked in not enrolled in the arena.");
        }

        [Test]
        public void Test_FightMethodThrowsWhenDefenderIsNotEnrolled()
        {
            arena.Enroll(warrior);

            var notEnrolledWarrior = new Warrior("tonko", 10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior.Name, notEnrolledWarrior.Name);

            }, "Fight method doesn't throw when defener in not enrolled in the arena.");
        }

        [Test]
        public void Test_FightMethodExecutesSuccessfulFight()
        {
            arena.Enroll(warrior);

            var defender = new Warrior("Tonko", 50, 50);

            arena.Enroll(defender);

            var warriorHPAfterFight = warrior.HP - defender.Damage;
            var defenderHPAfterFight = defender.HP - warrior.Damage;

            defenderHPAfterFight = defenderHPAfterFight < 0 ? 0 : defenderHPAfterFight;

            var message = "Fight method doesn't work correctly.";

            arena.Fight(warrior.Name, defender.Name);

            Assert.IsTrue(warrior.HP == warriorHPAfterFight, message);
            Assert.IsTrue(defender.HP == defenderHPAfterFight, message);
        }
    }
}
