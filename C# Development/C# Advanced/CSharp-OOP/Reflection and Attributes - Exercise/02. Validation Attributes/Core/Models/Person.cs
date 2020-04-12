namespace ValidationAttributes.Core.Models
{
    public class Person
    {
        private const int minValue = 12;
        private const int maxValue = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(minValue, maxValue)]
        public int Age { get; private set; }
    }
}