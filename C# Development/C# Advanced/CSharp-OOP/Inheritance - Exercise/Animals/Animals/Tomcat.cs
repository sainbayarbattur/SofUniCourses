namespace Animals.Animals
{
    public class Tomcat : Animal
    {
        private const string gender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, gender)
        {
        }

        public override string Gender => gender;

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
