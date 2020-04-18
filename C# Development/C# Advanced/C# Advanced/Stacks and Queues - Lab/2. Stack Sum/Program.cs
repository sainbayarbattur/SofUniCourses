namespace _2._Stack_Sum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var stack = new Stack<int>(inputLine);

            string line = Console.ReadLine();

            while (line.ToLower() != "end")
            {
                string command = line.Split(' ')[0];
                int[] args = line.Split(' ').Where((e, i) => i != 0).Select(int.Parse).ToArray();

                if (command.ToLower() == "add")
                {
                    stack.Push(args[0]);
                    stack.Push(args[1]);
                }
                else if (command.ToLower() == "remove")
                {
                    if (stack.Count < args[0])
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < args[0]; i++)
                    {
                        stack.Pop();
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Sum: " +  stack.Sum());
        }
    }
}