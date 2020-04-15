namespace Tests
{
    using System;
    using FightingArena;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class ArenaTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;

        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior("Geshkata", 12, 31);
            this.secondWarrior = new Warrior("Valerikata", 20, 31);
        }

        [Test]
        public void TestConstructor()
        {
            var arena = new Arena();

            CollectionAssert.AreEqual(arena.Warriors, new List<Warrior>());
        }

        [Test]
        public void TestEnrollMethod()
        {
            var arena = new Arena();

            arena.Enroll(secondWarrior);

            Assert.AreEqual(arena.Warriors.Count, 1);
        }

        [Test]
        public void TestEnrollMethodCorrectList()
        {
            Arena arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            var expected = new List<Warrior> { firstWarrior, secondWarrior };

            CollectionAssert.AreEqual(expected, arena.Warriors);
        }

        [Test]
        public void TestEnrollMethodShouldThrowExeption()
        {
            var arena = new Arena();

            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(firstWarrior));
        }

        [Test]
        public void TestFightMethodShouldThrowExeption()
        {
            var arena = new Arena();

            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWarrior.Name, "pesh01234"));

            arena = new Arena();

            arena.Enroll(new Warrior("pesh01234", 20, 31));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(secondWarrior.Name, "pesh01234"), $"There is no fighter with name {secondWarrior.Name} enrolled for the fights!");
        }

        [Test]
        public void TestFightMethod()
        {
            Arena arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            arena.Fight("Geshkata", "Valerikata");

            var expectedPeshoHp = 31 - 20;
            var actual = firstWarrior.HP;
            Assert.AreEqual(expectedPeshoHp, actual);
        }
    }
}