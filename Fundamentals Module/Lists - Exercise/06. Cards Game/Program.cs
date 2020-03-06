namespace CardsGame
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            List<int> firstPlayers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayers.Count != 0 && secondPlayers.Count != 0)
            {
                int firtsPlayerCard = firstPlayers[0];
                int secondPlayerCard = secondPlayers[0];

                if (firtsPlayerCard > secondPlayerCard)
                {
                    RemovePlayerCard(firstPlayers, secondPlayers);

                    firstPlayers.Add(firtsPlayerCard);
                    firstPlayers.Add(secondPlayerCard);
                }
                else if (secondPlayerCard > firtsPlayerCard)
                {
                    RemovePlayerCard(firstPlayers, secondPlayers);

                    secondPlayers.Add(secondPlayerCard);
                    secondPlayers.Add(firtsPlayerCard);
                }
                else
                {
                    RemovePlayerCard(firstPlayers, secondPlayers);
                }
            }
            if (firstPlayers.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayers.Sum()}");
            }
            else if (secondPlayers.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayers.Sum()}");
            }
        }

        public static void RemovePlayerCard(List<int> firstPlayers, List<int> secondPlayers)
        {
            firstPlayers.RemoveAt(0);
            secondPlayers.RemoveAt(0);
        }
    }
}
