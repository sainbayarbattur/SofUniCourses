namespace Problem_3._Oldest_Family_Member
{
    using System.Collections.Generic;
    using System.Linq;
    using DefiningClasses;

    class Family
    {
        private List<Person> FamilyList { get; set; } = new List<Person>();

        public void AddMember(Person person)
        {
            FamilyList.Add(person);
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;

            var oldestPerson = new Person();

            for (int i = 0; i < FamilyList.Count; i++)
            {
                if (FamilyList[i].Age > maxAge)
                {
                    oldestPerson = FamilyList[i];
                    maxAge = oldestPerson.Age;
                }
            }

            return oldestPerson;
        }
    }
}
