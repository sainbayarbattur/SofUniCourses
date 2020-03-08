namespace Balanced_Parentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var firstStack = new Queue<char>();

            var secondStack = new Stack<char>();

            int b = 0;

            bool isItBalanced = false;

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                firstStack.Enqueue(input[i]);
                b++;
            }

            for (int i = b; i < input.Length; i++)
            {
                secondStack.Push(input[i]);
            }

            for (int i = 0; i < secondStack.Count; i++)
            {
                char firstChar = firstStack.Dequeue();
                char secondChar = secondStack.Pop();

                if (firstChar == '{' && secondChar == '}')
                {
                    isItBalanced = true;
                    //continue;
                }
                else if (firstChar == '[' && secondChar == ']')
                {
                    isItBalanced = true;
                    ///continue;
                }
                else if (firstChar == '(' && secondChar == ')')
                {
                    isItBalanced = true;
                    //continue;
                }
                else
                {
                    isItBalanced = false;
                    //break;
                }
            }

            if (isItBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
