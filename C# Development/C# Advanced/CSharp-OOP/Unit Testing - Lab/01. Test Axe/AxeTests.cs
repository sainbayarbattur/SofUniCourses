namespace Tests
{
    using System;
    using NUnit.Framework;

    public class AxeTests
    {
        private Axe axe;

        const int axeAttack = 10;
        const int axeDurability = 10;

        [SetUp]
        public void Setup()
        {
            this.axe = new Axe(axeAttack, axeDurability);
        }

        [Test]
        public void TestAxeConstructor()
        {
            Assert.AreEqual(this.axe.AttackPoints, axeAttack);
            Assert.AreEqual(this.axe.DurabilityPoints, axeDurability);
        }

        [Test]
        [TestCase(10, 10)]
        public void TestAttackMethod(int health, int experience)
        {
            var dummy = new Dummy(health, experience);

            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 9);
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(20, -1)]
        public void TestAttackMethodShouldThrowExeption(int attackPoints, int durabilityPoints)
        {
            var axe = new Axe(attackPoints, durabilityPoints);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(1, 1)));
        }
    }
}
