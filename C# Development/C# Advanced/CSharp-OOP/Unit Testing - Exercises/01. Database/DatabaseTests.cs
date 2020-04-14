namespace Tests
{
    using System;
    using Database;
    using NUnit.Framework;

    public class DatabaseTests
    {
        private const int firstItem = 0;
        private const int secondItem = 1;
        private const int thirdItem = 2;
        private const int fourthItem = 3;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var database = new Database(firstItem, secondItem, thirdItem, fourthItem);

            Assert.AreEqual(4, database.Count);
        }

        [Test]
        public void TestAddMethodShouldThrowAnExeption()
        {
            var database = new Database(firstItem, secondItem, thirdItem, fourthItem, 5, 6 ,7 ,8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(12));
        }

        [Test]
        public void TestAddMethodShouldAdd()
        {
            var database = new Database(firstItem, secondItem, thirdItem, fourthItem);

            database.Add(12);

            Assert.AreEqual(5, database.Count);
        }

        [Test]
        public void TestRemoveMethodShouldRemove()
        {
            var database = new Database(firstItem, secondItem);

            database.Remove();

            Assert.AreEqual(database.Count, 1);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExeption()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestFetchMethodReturnCurrentArray()
        {
            var database = new Database(firstItem, secondItem);

            Assert.AreEqual(database.Fetch(), new int[] { firstItem, secondItem });
        }
    }
}