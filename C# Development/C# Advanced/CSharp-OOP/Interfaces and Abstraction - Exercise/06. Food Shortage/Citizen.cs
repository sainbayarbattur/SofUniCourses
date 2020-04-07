namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private int food = 0;
        public Citizen(string name, int age, string id)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public double Age { get; set; }
        public string Id { get; set; }

        public int Food { get => food; set => this.food = value; }

        public void BuyFood()
        {
            food += 10;
        }
    }
}