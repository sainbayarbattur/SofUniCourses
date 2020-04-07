namespace Problem_5._Football_Team_Generator
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            var teams = new List<Team>();

            while (line != "END")
            {
                try
                {

                    string command = line.Split(';')[0];

                    string[] info = line.Substring(command.Length + 1).Split(';');

                    string teamName = info[0];
                    var team = teams.Find(t => t.Name == teamName);

                    if (team == null && command != "Team")
                    {
                        throw new Exception($"Team {teamName} does not exist.");
                    }

                    if (command == "Team")
                    {
                        var teamToAdd = new Team(teamName);

                        teams.Add(teamToAdd);
                    }
                    else if (command == "Add")
                    {
                        string playerName = info[1];
                        int endurance = int.Parse(info[2]);
                        int sprint = int.Parse(info[3]);
                        int dribble = int.Parse(info[4]);
                        int passing = int.Parse(info[5]);
                        int shooting = int.Parse(info[6]);

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string playerName = info[1];

                        var player = team.FindPlayer(playerName);

                        team.RemovePlayer(player);
                    }
                    else if (command == "Rating")
                    {
                        Console.WriteLine(teamName + " - " + team.Rating);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
