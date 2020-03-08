using System;
using System.Collections.Generic;

namespace Problem_5._Comparing_Objects
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            int resultName = Name.CompareTo(other.Name);
            if (resultName == 0)
            {
                int resultAge = Age.CompareTo(other.Age);
                if (resultAge == 0)
                {
                    int resultTown = Town.CompareTo(other.Town);
                }
                return resultAge;
            }

            return resultName;
        }
    }
}
