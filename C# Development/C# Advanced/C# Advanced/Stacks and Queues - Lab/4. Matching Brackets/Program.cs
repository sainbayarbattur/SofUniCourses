namespace _4._Matching_Brackets
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string expression = Console.ReadLine();

            var openingBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(') openingBrackets.Push(i);

                if (expression[i] == ')')
                {
                    var currentClosingBracketIndex = openingBrackets.Pop();
                    Console.WriteLine(Substring(expression, currentClosingBracketIndex, i));
                }
            }
        }

        public static string Substring(string expression, int start, int end)
        {
            return expression.Substring(start, Math.Abs(end - start) + 1);
        }
    }
}