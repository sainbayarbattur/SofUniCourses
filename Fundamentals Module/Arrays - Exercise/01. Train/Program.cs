namespace Train
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int countWagons = int.Parse(Console.ReadLine());
            int[] people = new int[countWagons];

            int result = 0;

            for (int i = 0; i < countWagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                result += people[i];
            }

            for (int i = 0; i < countWagons; i++)
            {
                Console.Write(people[i] + " ");
            }
            Console.WriteLine();

            Console.Write(string.Join(" ", result));
            Console.Read();
        }
    }
}