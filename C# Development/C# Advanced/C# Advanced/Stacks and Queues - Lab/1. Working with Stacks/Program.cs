namespace I._Working_with_Stacks
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input);

            var count = stack.Count;

            for (int i = 0; i < count; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}