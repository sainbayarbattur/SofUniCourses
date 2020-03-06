namespace MultiplyBigNumber
{
    using System;
    using System.Numerics;
    public class Program
    {
        public static void Main()
        {
            BigInteger firstInput = BigInteger.Parse(Console.ReadLine());
            int secondInput = int.Parse(Console.ReadLine());
            firstInput *= secondInput;

            Console.WriteLine(firstInput);
        }
    }
}
