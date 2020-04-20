namespace _7._SoftUni_Party
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Guest
    {
        public Guest(string name)
        {
            this.Name = name;
            this.Type = this.GetGuestType();
        }

        private string GetGuestType()
        {
            return char.IsNumber(this.Name[0]) ? "VIP" : "regular";
        }

        public string Name { get; private set; }

        public string Type { get; private set; }
    }

    public class Program
    {
        public static void Main()
        {
            var invited = new HashSet<Guest>();
            var come = new HashSet<Guest>();

            string command = Console.ReadLine();
            var party = false;

            while (command != "END")
            {
                if (command == "PARTY") party = true;

                if (party && command != "PARTY")
                {
                    come.Add(new Guest(command));
                }

                if (!party)
                {
                    invited.Add(new Guest(command));
                }

                command = Console.ReadLine();
            }

            //var didntCome = invited.Select(i => i.Name).Where(i => !come.Select(c => c.Name).ToList().Contains(i)).ToList();

            var vipsThatDidntCome = invited
                .Where(g => g.Type == "VIP")
                .Select(v => v.Name)
                .Where(i => !come.Select(c => c.Name).ToList().Contains(i))
                .ToList();

            var regularGuestsThatDidntCome = invited
                .Where(g => g.Type == "regular")
                .Select(v => v.Name)
                .Where(i => !come.Select(c => c.Name).ToList().Contains(i))
                .ToList();

            Console.WriteLine(vipsThatDidntCome.Count + regularGuestsThatDidntCome.Count);
            if (vipsThatDidntCome.Count > 0) Console.WriteLine(string.Join('\n', vipsThatDidntCome));
            if (regularGuestsThatDidntCome.Count > 0) Console.WriteLine(string.Join('\n', regularGuestsThatDidntCome));
        }
    }
}