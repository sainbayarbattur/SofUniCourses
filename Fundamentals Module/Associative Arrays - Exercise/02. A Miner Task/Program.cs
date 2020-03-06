namespace AMinerTask
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, int>();

            while (true)
            {
                string stringInputData = Console.ReadLine();

                if (stringInputData == "stop")
                {
                    break;
                }
                int number = int.Parse(Console.ReadLine());

                if (result.ContainsKey(stringInputData))
                {
                    result[stringInputData] += number;
                    continue;
                }

                result.Add(stringInputData, number);
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
