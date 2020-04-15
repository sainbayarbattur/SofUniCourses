namespace Tests
{
    using NUnit.Framework;
    using System;

    public class DummyTests
    {
        private Dummy dummy;

        private const int health = 10;
        private const int experience = 10;

        [SetUp]
        public void Setup()
        {
            this.dummy = new Dummy(health, experience);
        }

        [Test]
        public void TestIsDeadMethod()
        {
            var dummy = new Dummy(0, 0);

            Assert.IsTrue(dummy.Health <= 0);
        }

        [Test]
        public void TestTakeAttackMethod()
        {
            dummy.TakeAttack(10);

            Assert.AreEqual(dummy.Health, 0);
        }

        [Test]
        public void TestTakeAttackMethodShouldThrowExeption()
        {
            var dummy = new Dummy(0, 0);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(12));
        }

        [Test]
        public void TestGiveExperienceMethod()
        {
            dummy.TakeAttack(10);

            Assert.AreEqual(dummy.GiveExperience(), 10);
        }

        [Test]
        public void TestGiveExperienceMethodShouldThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}