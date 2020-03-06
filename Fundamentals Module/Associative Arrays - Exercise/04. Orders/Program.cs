namespace Orders1
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            var productQuanity = new Dictionary<string, int>();
            var productPrice = new Dictionary<string, double>();

            while (true)
            {
                List<string> current = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                if (current.Contains("buy"))
                {
                    break;
                }

                string currProduct = current[0];
                double currPrice = double.Parse(current[1]);
                int quantity = int.Parse(current[2]);

                if (!productQuanity.ContainsKey(currProduct))
                {
                    productQuanity.Add(currProduct, 0);
                    productPrice.Add(currProduct, 0);
                }

                productQuanity[currProduct] += quantity;
                productPrice[currProduct] = currPrice;
            }

            foreach (var item in productQuanity)
            {
                string name = item.Key;
                double finalSum = item.Value * productPrice[name];
                Console.WriteLine("{0} -> {1:F2}", name, finalSum);
            }
        }
    }
}
