namespace _08._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var contests = new Dictionary<string, string>();
            var candidates = new Dictionary<string, Dictionary<string, int>>();

            string contestInfo = Console.ReadLine();

            while (contestInfo != "end of contests")
            {
                string contestName = contestInfo.Split(':')[0];
                string password = contestInfo.Split(':')[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }

                contestInfo = Console.ReadLine();
            }

            string submitionInfo = Console.ReadLine();

            while (submitionInfo != "end of submissions")
            {
                string contestName = submitionInfo.Split("=>")[0];
                string password = submitionInfo.Split("=>")[1];
                string username = submitionInfo.Split("=>")[2];
                int points = int.Parse(submitionInfo.Split("=>")[3]);

                if (!contests.ContainsKey(contestName) || contests[contestName] != password) 
                {
                    submitionInfo = Console.ReadLine();
                    continue;
                }

                if (!candidates.ContainsKey(username))
                {
                    candidates.Add(username, new Dictionary<string, int>());
                }

                if (!candidates[username].ContainsKey(contestName))
                {
                    candidates[username].Add(contestName, -1);
                }

                if (points > candidates[username][contestName])
                {
                    candidates[username][contestName] = points;
                }

                submitionInfo = Console.ReadLine();
            }

            var bestCandidate = candidates.Keys.OrderByDescending(k => candidates[k].Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {candidates[bestCandidate].Values.Sum()} points.");
            Console.WriteLine("Ranking: ");

            foreach (var candidate in candidates.OrderBy(c => c.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine("#  " + contest.Key + " -> " + contest.Value);
                }
            }
        }
    }
}