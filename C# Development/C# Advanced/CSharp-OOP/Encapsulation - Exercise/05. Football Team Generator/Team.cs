namespace Problem_5._Football_Team_Generator
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        private string name;

        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public Player FindPlayer(string playerName)
        {
            var player = this.players.Find(p => p.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }

            return player;
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                double teamRating = 0;

                foreach (var player in this.players)
                {
                    teamRating += player.Rating;
                }

                teamRating /= this.players.Count;

                return (int)Math.Round(teamRating);
            }
        }

        public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }
    }
}
