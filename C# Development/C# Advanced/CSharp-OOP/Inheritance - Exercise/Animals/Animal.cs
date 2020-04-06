using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Invalid input!");
                }

                age = value;
            } 
        }

        public string Name { get; }

        public virtual string Gender { get; }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(this.GetType().Name);

            strBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            strBuilder.Append(this.ProduceSound());

            return strBuilder.ToString();
        }
    }
}
