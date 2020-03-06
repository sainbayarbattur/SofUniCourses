namespace ObjectsAndClasseExercise
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var result = new List<string>();
            Random randPhrases = new Random();
            Random randCities = new Random();
            Random randEvents = new Random();
            Random randAuthors = new Random();

            string[] phrases = {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] cities = {
                "Burgas","Sofia",
                "Plovdiv","Varna",
                "Ruse"
            };

            string[] events = {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = {
                "Diana","Petya",
                "Stella","Elena",
                "Katya","Iva",
                "Annie","Eva"
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int randIndexP = randPhrases.Next(0, phrases.Length);
                int randIndexC = randCities.Next(0, cities.Length);
                int randIndexE = randEvents.Next(0, events.Length);
                int randIndexA = randAuthors.Next(0, authors.Length);
                result.Add(phrases[randIndexP] + " ");
                result.Add(events[randIndexE] + " ");
                result.Add(authors[randIndexA] + " - ");
                result.Add(cities[randIndexC]);
                Console.WriteLine(string.Join("", result));
                result.RemoveAll(x => result.Contains(x));
            }
        }
    }
}
