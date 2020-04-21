namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();

            var addVat = new Func<double, string>((input) =>
            {
                return (input + input * 0.2).ToString("f2");
            });

            var result = input.Select(addVat);

            Console.WriteLine(string.Join('\n', result));
        }
    }
}