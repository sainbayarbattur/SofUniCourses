namespace TeamworkProjects
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        class Team
        {
            public string UserCreator { get; set; }
            public string TeamName { get; set; }

            public List<string> Users { get; set; }

            public Team(string user, string teamName, List<string> users)
            {
                UserCreator = user;
                TeamName = teamName;
                Users = users;
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var users = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('-').ToList();
                string user = input[0];
                string teamName = input[1];
                var currentTeam = new Team(user, teamName, new List<string>());
                if (users.Any(x => x.UserCreator == user) || users.Any(x => x.TeamName == teamName))
                {
                    if (users.Any(x => x.TeamName == teamName))
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                    else
                    {
                        Console.WriteLine($"{user} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                    currentTeam.UserCreator = user;

                    users.Add(currentTeam);
                }
            }
            while (true)
            {
                string inputv = Console.ReadLine();
                if (inputv == "end of assignment")
                {
                    break;
                }
                string[] tokens = inputv.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                string userToJoin = tokens[0];
                string teamToJoin = tokens[1];

                bool noneExistTeam = false;
                bool existUser = false;

                if (!ExistTeam(teamToJoin, users))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    noneExistTeam = true;
                }
                else if (ExistUser(userToJoin, users))
                {
                    Console.WriteLine($"Member {userToJoin} cannot join team {teamToJoin}!");
                    existUser = true;
                }
                if (!noneExistTeam && !existUser)
                {
                    foreach (var team in users.Where(x => x.TeamName == teamToJoin))
                    {
                        team.Users.Add(userToJoin);
                        break;
                    }
                }
            }
            foreach (var team in users.Where(x => x.Users.Count > 0).OrderByDescending(x => x.Users.Count).ThenBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);

                Console.WriteLine("- {0}", team.UserCreator);

                foreach (var name in team.Users.OrderBy(x => x))
                {
                    Console.WriteLine("-- {0}", name);
                }
            }
            Console.WriteLine("Teams to disband:");

            foreach (var team in users.Where(x => x.Users.Count == 0).OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }

        private static bool ExistTeam(string teamToJoin, List<Team> users)
        {
            foreach (var item in users)
            {
                if (item.TeamName == teamToJoin)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ExistUser(string userToJoin, List<Team> users)
        {
            foreach (var item in users)
            {
                if (item.UserCreator == userToJoin || item.Users.Contains(userToJoin))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
