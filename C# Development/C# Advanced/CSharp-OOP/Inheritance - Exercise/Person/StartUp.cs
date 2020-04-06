namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            int age = int.Parse(Console.ReadLine());

            var child = new Child(name, age);

            Console.WriteLine(child);
        }
    }
}