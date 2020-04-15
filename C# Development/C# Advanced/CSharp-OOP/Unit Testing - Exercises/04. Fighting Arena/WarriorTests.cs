namespace Tests
{
    using System;
    using FightingArena;
    using NUnit.Framework;

    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Gosho", 2, 31);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(warrior.Name, "Gosho");
            Assert.AreEqual(warrior.Damage, 2);
            Assert.AreEqual(warrior.HP, 31);
        }

        [Test]
        public void TestNameProperty()
        {
            Assert.AreEqual(warrior.Name, "Gosho");
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void TestNamePropertyShouldThowExeption(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, warrior.Damage, warrior.HP));
            Assert.Throws<ArgumentException>(() => new Warrior(name, warrior.Damage, warrior.HP));
        }

        [Test]
        public void TestDamageProperty()
        {
            Assert.AreEqual(warrior.Damage, 2);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestDamagePropertyShouldThowExeption(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(warrior.Name, damage, warrior.HP));
        }

        [Test]
        public void TestHPProperty()
        {
            Assert.AreEqual(warrior.HP, 31);
        }

        [Test]
        public void TestHPPropertyShouldThowExeption()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(warrior.Name, warrior.Damage, -1));
        }

        [Test]
        public void TestAttackMethod()
        {
            var defender = new Warrior("Defender", 1, 60);

            warrior.Attack(defender);

            Assert.AreEqual(30, warrior.HP);
            Assert.AreEqual(58, defender.HP);

            var warr1 = new Warrior("gosho 2.0", 60, 60);
            var warr2 = new Warrior("slabak", 12, 31);

            warr1.Attack(warr2);

            Assert.AreEqual(warr1.HP, 48);
            Assert.AreEqual(warr2.HP, 0);
        }

        [Test]
        public void TestAttackMethodShouldThowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => new Warrior(warrior.Name, warrior.Damage, 1).Attack(new Warrior(warrior.Name, warrior.Damage, 1)));
            Assert.Throws<InvalidOperationException>(() => new Warrior(warrior.Name, warrior.Damage, 31).Attack(new Warrior(warrior.Name, warrior.Damage, 1)));
            Assert.Throws<InvalidOperationException>(() => new Warrior(warrior.Name, warrior.Damage, 31).Attack(new Warrior(warrior.Name, 1000, 31)));
        }

        [Test]
        [TestCase(28)]
        public void WarriorTestArguemtExceptionWarriorCantAttackWithLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, hp);
            Warrior defender = new Warrior("Bai Pesho", 10, 40);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(28)]
        public void TestAttackMethodArguemtExceptionWarriorCantBeAttackedWhenLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", 10, hp);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(58)]
        public void TestAttackMethodArguemtExceptionAtackingStrongerOpponent(int dmg)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", dmg, 40);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(22, 40)]
        public void TestAtackMethodCorrectly(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 50 - dmg;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(51, 40)]
        public void TestAtackMethodCorrectlyWithMoreDamage(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 0;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }
    }
}