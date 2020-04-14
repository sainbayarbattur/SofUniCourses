namespace Tests
{
    //using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    public class ExtendedDatabaseTests
    {
        private Person firstPerson;
        private Person secondPerson;
        private Person thirdPerson;
        private Person fourthPerson;

        [SetUp]
        public void Setup()
        {
            firstPerson = new Person(1, "Tonkata");
            secondPerson = new Person(2, "Toshkata");
            thirdPerson = new Person(3, "Petko");
            fourthPerson = new Person(4, "Pesho");
        }

        [Test]
        public void TestConstructor()
        {
            var database = new ExtendedDatabase(firstPerson, secondPerson, thirdPerson, fourthPerson);

            Assert.AreEqual(database.Count, 4);
        }

        [Test]
        public void TestAddMethodShouldThrowAnExeption()
        {
            var database = new ExtendedDatabase(firstPerson, secondPerson, thirdPerson, fourthPerson);

            for (int i = 5; i <= 16; i++)
            {
                database.Add(new Person(i, "neshto si tam" + i));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(70, "neshto si tami")));

            database = new ExtendedDatabase(firstPerson);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(firstPerson.Id, "ne e sushtot")));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(123456, firstPerson.UserName)));
        }

        [Test]
        public void TestAddMethod()
        {
            var database = new ExtendedDatabase(firstPerson);

            database.Add(secondPerson);

            Assert.AreEqual(database.Count, 2);
        }

        [Test]
        public void TestAddRangeMethod()
        {
            var database = new ExtendedDatabase(firstPerson);

            Assert.AreEqual(database.Count, 1);
        }

        [Test]
        public void TestAddRangeMethodShouldThrowAnExeption()
        {
            var persons = new Person[17];

            for (int i = 5; i <= 16; i++)
            {
                persons[i] = new Person(i, "neshto si tam" + i);
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));
        }

        [Test]
        public void TestRemoveMethodShouldThrowAnExeption()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestRemoveMethod()
        {
            var database = new ExtendedDatabase(firstPerson);

            database.Remove();

            Assert.AreEqual(database.Count, 0);
        }

        [Test]
        public void TestFindByUsernameMethod()
        {
            var database = new ExtendedDatabase(firstPerson);

            Assert.AreEqual(database.FindByUsername("Tonkata"), firstPerson);
        }

        [Test]
        public void TestFindByUsernameMethodShouldThrowExeption()
        {
            var database = new ExtendedDatabase(firstPerson);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("pesh11o"));

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void TestFindByIdMethod()
        {
            var database = new ExtendedDatabase(firstPerson);

            Assert.AreEqual(database.FindById(1), firstPerson);
        }

        [Test]
        public void TestFindByIdeMethodShouldThrowExeption()
        {
            var database = new ExtendedDatabase(firstPerson);

            Assert.Throws<InvalidOperationException>(() => database.FindById(101));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
    }
}