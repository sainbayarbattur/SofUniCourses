namespace Train1
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] token = Console.ReadLine().Split();
                if (token[0].ToString() == "end")
                {
                    break;
                }

                if (token[0].ToString() == "Add")
                {
                    int wagonsToAdd = int.Parse(token[1].ToString());
                    numbers.Add(wagonsToAdd);
                }
                else
                {
                    int peopleToAdd = int.Parse(token[0].ToString());

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int currentPass = numbers[i];
                        if (peopleToAdd + currentPass <= n)
                        {
                            numbers[i] += peopleToAdd;
                            break;
                        }
                    }

                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
