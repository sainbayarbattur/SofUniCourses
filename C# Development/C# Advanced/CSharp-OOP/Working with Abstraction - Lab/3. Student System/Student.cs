namespace _3StudentSystem
{
    public class Student
    {
        private double grade;

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }

        public string Comment 
        {
            get
            {
                if (this.grade >= 5.50)
                {
                    return "Excellent student";
                }
                else
                {
                    return "Average student";
                }
            }
        }

        public string Name { get; }

        public int Age { get; }

        public override string ToString()
        {
            return $"{this.Name} is {this.Age} years old. {this.Comment}.";
        }
    }
}