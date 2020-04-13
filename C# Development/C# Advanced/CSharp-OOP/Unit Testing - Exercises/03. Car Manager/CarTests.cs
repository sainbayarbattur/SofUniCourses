namespace Tests
{
    using System;
    //using CarManager;
    using NUnit.Framework;

    public class CarTests
    {
        private const string expectedMake = "make";
        private const string expectedModel = "model";
        private const double expectedFuelConsumption = 50.2;
        private const double expectedFuelCapacity = 100.00;
        private const double initialFuelAmount = 0;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string make = car.Make;
            string model = car.Model;
            double fuelConsumption = car.FuelConsumption;
            double fuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedMake, make);
            Assert.AreEqual(expectedModel, model);
            Assert.AreEqual(expectedFuelConsumption, fuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, fuelCapacity);
        }

        [Test]
        public void TestGetMakeProperty()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string make = car.Make;

            Assert.AreEqual(expectedMake, make);
        }

        [Test]
        public void TestGetModelProperty()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string model = car.Model;

            Assert.AreEqual(expectedModel, model);
        }

        [Test]
        public void TestGetFuelConsumptionProperty()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            double fuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, fuelConsumption);
        }

        [Test]
        public void TestGetFuelCapacityProperty()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            double fuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, fuelCapacity);
        }

        [Test]
        public void TestPostMakeProperty()
        {
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, expectedModel, expectedFuelConsumption, expectedFuelCapacity), "Make cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new Car(null, expectedModel, expectedFuelConsumption, expectedFuelCapacity), "Make cannot be null or empty!");
        }

        [Test]
        public void TestPostModelProperty()
        {
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, string.Empty, expectedFuelConsumption, expectedFuelCapacity), "Model cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, null, expectedFuelConsumption, expectedFuelCapacity), "Model cannot be null or empty!");
        }

        [Test]
        public void TestPostFuelConsumptionProperty()
        {
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, expectedModel, -1, expectedFuelCapacity), "Fuel consumption cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, expectedModel, 0, expectedFuelCapacity), "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void TestPostFuelCapacityProperty()
        {
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, expectedModel, expectedFuelConsumption, -1));
            Assert.Throws<ArgumentException>(() => new Car(expectedMake, expectedModel, expectedFuelConsumption, 0));

        }

        [Test]
        public void TestGetFuelAmountProperty()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            double fuelAmount = car.FuelAmount;

            Assert.AreEqual(initialFuelAmount, fuelAmount);
        }

        [Test]
        public void TestRefuelMethodShouldThrowAnExeption()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-10));
        }

        [Test]
        public void TestRefuelMethod()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(10);

            Assert.AreEqual(car.FuelAmount, 10);

            car.Refuel(101);

            Assert.AreEqual(car.FuelAmount, expectedFuelCapacity);
        }

        [Test]
        public void TestDriveMethodShouldThrowAnExeption()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10000000));
        }

        [Test]
        public void TestDrivelMethod()
        {
            var car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(1000);

            car.Drive(10);

            Assert.AreEqual(car.FuelAmount, 94.98);
        }
    }
}