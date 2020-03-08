namespace Even_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var dic = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currInput = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(currInput))
                {
                    dic.Add(currInput, 0);
                }

                dic[currInput]++;
            }

            foreach (var item in dic.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
