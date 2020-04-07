namespace Telephony
{
    using System;
    using System.Linq;
    using Problem_3._Telephony;

    public class Program
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split(' ').ToList();
            var sites = Console.ReadLine().Split(' ').ToList();

            var smartphone = new Smartphone();

            var stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                try
                {
                    if (phoneNumbers[i].ToString().Length == 7)
                    {
                        stationaryPhone.Phone = phoneNumbers[i];
                        Console.WriteLine(stationaryPhone.Deal());
}
                    else
                    {
                        smartphone.Phone = phoneNumbers[i];
                        Console.WriteLine(smartphone.Call());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < sites.Count; i++)
            {
                try
                {
                    smartphone.Site = sites[i];
                    Console.WriteLine(smartphone.Browsing());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}