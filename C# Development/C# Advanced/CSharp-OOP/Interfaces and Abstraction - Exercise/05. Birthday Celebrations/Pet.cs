namespace BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}