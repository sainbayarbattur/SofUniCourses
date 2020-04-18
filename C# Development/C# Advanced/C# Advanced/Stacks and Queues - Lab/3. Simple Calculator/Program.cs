namespace _3._Simple_Calculator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stackNumbers = new Stack<int>(input.Split(' ').Where((e, i) => i % 2 == 0).Select(int.Parse).ToArray().Reverse());
            var stackOperators = new Stack<string>(input.Split(' ').Where((e, i) => i % 2 != 0).ToArray().Reverse());

            int firstNumber = stackNumbers.Pop();

            int result = firstNumber;

            while (stackOperators.Count > 0)
            {
                string currOperator = stackOperators.Pop();

                int secondNumber = stackNumbers.Pop();

                if (currOperator == "+")
                {
                    result += secondNumber;
                }
                else if (currOperator == "-")
                {
                    result -= secondNumber;
                }

                firstNumber = result;
            }

            Console.WriteLine(result);
        }
    }
}