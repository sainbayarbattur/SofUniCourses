namespace _2PointinRectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var intialsCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var topLeft = new Point(intialsCoordinates[0], intialsCoordinates[1]);

            var bottomRight = new Point(intialsCoordinates[2], intialsCoordinates[3]);

            var rectangle = new Rectangle(topLeft , bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var point = new Point(line[0], line[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}