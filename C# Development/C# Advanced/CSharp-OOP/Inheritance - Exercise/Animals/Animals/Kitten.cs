namespace Animals.Animals
{
    public class Kitten : Animal
    {
        private const string gender = "Female";

        public Kitten(string name, int age)
            : base(name, age, gender)
        {
        }

        public override string Gender => gender;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
