namespace Problem_5._Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    public class Player
    {
        private const double statsCount = 5;

        private string name;
        private double rating;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            FullUpStats(endurance, sprint, dribble, passing, shooting);
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception($"Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception($"Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception($"Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception($"Endurance should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception($"Endurance should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

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

        public int Rating 
        {
            get
            {
                this.rating = (this.Passing + this.Shooting + this.Endurance + this.Sprint + this.Dribble) / statsCount;

                return (int)Math.Round(rating);
            }
        }

        private void FullUpStats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
    }
}
