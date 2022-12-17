namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        private Warrior defender;

        private const int minHP = 30;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("David", 100, 100);
            defender = new Warrior("Other", 50, 50);
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(null, 10, 10);
            }, "Warrior ctor doesn't throw when name is null.");
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenNameIsWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("  ", 10, 10);
            }, "Warrior ctor doesn't throw when name is whitespace.");
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenNameIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(string.Empty, 10, 10);
            }, "Warrior ctor doesn't throw when name is empty.");
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenDamageIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("warrior", 0, 10);
            }, "Warrior ctor doesn't throw when warrior damage is 0.");
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenDamageIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("warrior", -10, 10);
            }, "Warrior ctor doesn't throw when warrior damage is negative.");
        }

        [Test]
        public void Test_WarriorCtorThrowsWhenHPIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("warrior", 10, -10);
            }, "Warrior ctor doesn't throw when warrior HP is negative.");
        }

        [Test]
        public void Test_WarriorCtorCreatesWarriorWithValidArgs()
        {
            var expectedName = "warrior";
            var expectedDamage = 150;
            var expectedHP = 150;

            warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.IsTrue(warrior.Name == expectedName, "Ctor doesn't set the Name correctly.");
            Assert.IsTrue(warrior.Damage == expectedDamage, "Ctor doesn't set the Damage correctly.");
            Assert.IsTrue(warrior.HP == expectedHP, "Ctor doesn't set the HP correctly.");
        }

        [Test]
        public void Test_AttackMethodThrowsWhenAttackerHPIsBelowThreshold()
        {
            warrior = new Warrior("some warrior", 10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, $"Attack method should throw if attacked HP is lower than the threshold - {minHP}.");
        }

        [Test]
        public void Test_AttackMethodThrowsWhenAttackerHPIsEqualToThreshold()
        {
            warrior = new Warrior("some warrior", 10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, $"Attack method should throw if attacked HP is equal to the threshold - {minHP}.");
        }

        [Test]
        public void Test_AttackMethodThrowsWhenDefenderHPIsBelowThreshold()
        {
            defender = new Warrior("some", 10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, $"Attack method should throw if defender HP is lower than the threshold - {minHP}.");
        }

        [Test]
        public void Test_AttackMethodThrowsWhenDefenderHPIsEqualThreshold()
        {
            defender = new Warrior("some", 10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, $"Attack method should throw if defender HP is equal to the threshold - {minHP}.");
        }

        [Test]
        public void Test_AttackMethodThrowsWhenAttackingWarriorWithMoreDamageThanTheAttackerHP()
        {
            defender = new Warrior("Gosho", 10_100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, "Attack method should throw if defender damage is more than the attacker HP.");
        }

        [Test] 
        public void Test_AttackMethodLowersTheAttackingWarriorHP()
        {
            var warriorHealthBeforeAttack = warrior.HP;

            warrior.Attack(defender);

            var warriorHealthAfterAttack = warrior.HP;

            var difference = warriorHealthBeforeAttack - defender.Damage;

            Assert.True(warriorHealthAfterAttack == warriorHealthBeforeAttack - difference, "Attack method doesn't lower the attacker HP correctly.");
        }

        [Test]
        public void Test_AttackMethodLowersDefenderWarriorHPWhenDamageIsLessThanDefenderHP()
        {
            defender = new Warrior("some warrior", 10, 300);

            var defenderHPBeforeAttack = defender.HP;

            warrior.Attack(defender);

            var defenderHPAfterAttack = defender.HP;

            var difference = defenderHPBeforeAttack - warrior.Damage;

            Assert.IsTrue(defenderHPAfterAttack == difference, "Attack method doesn't lower the defender HP correctly when damage is lower than his HP.");
        }

        [Test]
        public void Test_AttackMethodLowersDefenderWarriorHPToZeroWhenDamageIsMoreThanDefenderHP()
        {
            warrior.Attack(defender);

            Assert.IsTrue(defender.HP == 0, "Attack method doesn't lower the defender HP to 0 when the attacker damage is more than the defender HP.");
        }
    }
}