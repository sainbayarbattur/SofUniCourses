namespace _11._Key_Revolver
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int priceGunBarrelSize = int.Parse(Console.ReadLine());

            var bulletsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var locksInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsInput);
            var locks = new Queue<int>(locksInput);

            int barels = 0;

            while (bullets.Count > 0)
            {
                var bullet = bullets.Pop();

                if (bullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                barels++;

                if (barels == priceGunBarrelSize && bullets.Count > 0)
                {
                    barels = 0;
                    Console.WriteLine("Reloading!");
                }

                if (bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                if (locks.Count == 0 && bullets.Count >= 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - ((bulletsInput.Count - bullets.Count) * pricePerBullet)}");
                    return;
                }
            }
        }
    }
}