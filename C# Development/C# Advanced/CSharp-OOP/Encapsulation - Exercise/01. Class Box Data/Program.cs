namespace ClassBoxDataValidation
{
    using System;
    public class Program
    {
        public static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);

            Console.WriteLine(box.ToString());
        }
    }
}
