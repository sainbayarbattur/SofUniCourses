namespace BorderControl
{
    public class Citizen : IId
    {
        public Citizen(string name, int age, string id)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public double Age { get; set; }
        public string Id { get; set; }
    }
}