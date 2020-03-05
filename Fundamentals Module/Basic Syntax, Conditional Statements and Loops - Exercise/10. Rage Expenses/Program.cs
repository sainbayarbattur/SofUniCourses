using System;

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal lostGames = decimal.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());
            decimal resultPrice = 0;
            decimal headsetBreakTimes = (int)lostGames / 2;
            decimal mouseBreakTimes = (int)lostGames / 3;
            decimal keyboardBreakTimes = 0;
            decimal displayBreakTimes = 0;

            if (headsetBreakTimes != 0 && mouseBreakTimes != 0)
            {
                keyboardBreakTimes = (int)lostGames / 6;
            }
            if (keyboardBreakTimes > 1)
            {
                displayBreakTimes = (int)lostGames / 12;
            }
            resultPrice = headsetBreakTimes * headsetPrice + mouseBreakTimes * mousePrice + keyboardBreakTimes * keyboardPrice + displayBreakTimes * displayPrice;
            Console.Write($"Rage expenses: {resultPrice:f2} lv.");
            Console.Read();
        }
    }
}
