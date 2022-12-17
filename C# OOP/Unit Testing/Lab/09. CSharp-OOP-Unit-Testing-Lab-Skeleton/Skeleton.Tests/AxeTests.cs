using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;

        private Dummy dummy = new Dummy(10, 10);

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void Test_WeaponShouldLoseDurabilityAfterAttack()
        {
            var durabilityBeforeAttack = axe.DurabilityPoints;

            axe.Attack(dummy);

            var durabilityAfterAttack = axe.DurabilityPoints;

            Assert.AreNotEqual(durabilityBeforeAttack, durabilityAfterAttack, "Axe doesn't lose health after attack.");
        }

        [Test]
        public void Test_WeaponShouldThrowIfBroken()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Weapon should throw if attacking when durability is equal or below 0.");
        }
    }
}