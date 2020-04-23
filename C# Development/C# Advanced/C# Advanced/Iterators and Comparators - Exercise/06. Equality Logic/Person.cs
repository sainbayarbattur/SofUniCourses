using System;

namespace _06EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return other.Age.CompareTo(this.Age);
            }

            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;

            if (this.Name == person.Name
                && this.Age == person.Age)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + this.Age.GetHashCode();
            hash = hash * 23 + this.Name.GetHashCode();
            return hash;
        }
    }
}