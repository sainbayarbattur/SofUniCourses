namespace BirthdayCelebrations
{
    public class Citizen : IBirthday
    {
        public Citizen(string name, int age, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
    }
}