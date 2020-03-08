using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main()
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var keyValuePairs = new Dictionary<int, int>();

        coins = coins.OrderByDescending(n => n).ToList();

        var coinIndex = 0;

        while (targetSum != 0 && coinIndex < coins.Count)
        {
            var count = targetSum / coins[coinIndex];
            if (count > 0)
            {
                targetSum -= count * coins[coinIndex];
                keyValuePairs.Add(coins[coinIndex], count);
            }
            
            coinIndex++;
        }

        if (targetSum > 0)
        {
            throw new Exception("Error");
        }

        return keyValuePairs;
    }
}