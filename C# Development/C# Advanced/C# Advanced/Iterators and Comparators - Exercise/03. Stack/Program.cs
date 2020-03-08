namespace Problem_3._Stack
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END") break;

                string command = input;

                if (command == "Pop")
                {
                    stack.Pop();
                }
                else
                {
                    var token = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (token.Count >= 2)
                    {
                        token.RemoveAt(0);

                        var result = token.Select(int.Parse).ToList();

                        stack.Push(result);
                    }
                }
            }

            if (stack.IsThereElements)
            {
                foreach (var number in stack)
                {
                    Console.WriteLine(number);
                }
                foreach (var number in stack)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }
    }
}
