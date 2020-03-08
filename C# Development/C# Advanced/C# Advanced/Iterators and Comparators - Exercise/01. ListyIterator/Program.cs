namespace Problem_1._ListyIterator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string createCommand = Console.ReadLine();

            var token = createCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            token.RemoveAt(0);

            var list = token;

            var c = new ListyIterator<string>(list);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END") break;

                string command = input;

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(c.Move());
                        break;
                    case "Print":
                        Console.WriteLine(c.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(c.HasNext());
                        break;
                }
            }
        }
    }
}
