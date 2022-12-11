using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        private const int dummyBaseHealth = 10;

        private const int dummyBaseXP = 10;

        private Axe axe;

        private const int axeBaseDurability = 5;

        private const int axeBaseAttack = 5;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(dummyBaseHealth, dummyBaseXP);
            axe = new Axe(axeBaseAttack, axeBaseDurability);
        }

        [Test]
        public void Test_DummyLosesHealthAfterAttack()
        {
            var healthBeforeAttack = dummy.Health;

            dummy.TakeAttack(axe.AttackPoints);

            var healthAfterAttack = dummy.Health;

            Assert.AreNotEqual(healthBeforeAttack, healthAfterAttack, "Dummy did not lose health after an attack.");
        }

        [Test]
        public void Test_DummyThrowsIfAttackedWhenIsDead()
        {
            dummy.TakeAttack(dummy.Health);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(axe.AttackPoints);
            }, "Dummy doesn't throw if health equal or below 0.");
        }

        [Test]
        public void Test_DeadDummyGivesXP()
        {
            dummy.TakeAttack(dummy.Health);

            var xp = dummy.GiveExperience();

            Assert.AreEqual(xp, dummyBaseXP, "Dummy didn't give XP points equal to the amount passed in the ctor when dead.");
        }

        [Test]
        public void Test_AliveDummyThrowsWhenGivingXP()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var xp = dummy.GiveExperience();
            }, $"Alive dummy should throw when {nameof(dummy.GiveExperience)} is called.");
        }

        [Test]
        public void Test_DummyIsDeadIfHealthIsZero()
        {
            dummy.TakeAttack(dummy.Health);

            var isDead = dummy.IsDead();

            Assert.IsTrue(isDead, "Dummy is not considered dead if health is 0.");
        }

        [Test]
        public void Test_DummyIsDeadIfHealthIsNegative()
        {
            dummy.TakeAttack(dummy.Health + axe.AttackPoints);

            var isDead = dummy.IsDead();

            Assert.IsTrue(isDead, "Dummy is not considered dead, when health is negative.");
        }

        [Test]
        public void Test_DummyIsAliveIfHealthIsPositive()
        {
            dummy.TakeAttack(axe.DurabilityPoints);

            var isDead = dummy.IsDead();

            Assert.IsFalse(isDead, "Dummy is not considered alive if health is above 0.");
        }
    }
}