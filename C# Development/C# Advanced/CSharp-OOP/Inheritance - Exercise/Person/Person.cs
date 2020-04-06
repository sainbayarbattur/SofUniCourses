namespace Person
{
    using System;

    public abstract class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 15)
                {
                    throw new Exception("Name should not be more than 15 chars long!!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Age should not be negative!!");
                }
                age = value; 
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}