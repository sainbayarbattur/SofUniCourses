using System;

namespace _10.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier.DatesDifference(date1, date2);
        }
    }
}