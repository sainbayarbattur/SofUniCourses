namespace AddAndSubtract
{
    using System;
    public class Program
    {
        public static int method = 0;
        public static void Main()
        {
            int firstInputData = int.Parse(Console.ReadLine());
            int secondInputData = int.Parse(Console.ReadLine());
            int thirdInputData = int.Parse(Console.ReadLine());

            method = SumFirstTwoInputDatas(firstInputData, secondInputData);
            Console.WriteLine(SubsrtactFirstTwoWithTheLast(thirdInputData));

            Console.Read();
        }

        public static int SumFirstTwoInputDatas(int a, int b)
        {
            return a + b;
        }

        public static int SubsrtactFirstTwoWithTheLast(int c)
        {
            return method - c;
        }
    }
}
