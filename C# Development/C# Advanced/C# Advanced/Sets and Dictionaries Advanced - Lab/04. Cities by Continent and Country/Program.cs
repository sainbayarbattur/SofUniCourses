namespace _04._Cities_by_Continent_and_Country
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string continentName = line[0];

                if (!continents.ContainsKey(continentName))
                {
                    continents.Add(continentName, new Dictionary<string, List<string>>());
                }

                if (continents.ContainsKey(continentName))
                {
                    string countryName = line[1];
                    string cityName = line[2];

                    if (!continents[continentName].Any(c => c.Key == countryName))
                    {
                        continents[continentName].Add(countryName, new List<string>());
                    }

                    //if (!continents[continentName][countryName].Any(c => c == cityName))
                    //{
                    //}

                    continents[continentName][countryName].Add(cityName);
                }
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}