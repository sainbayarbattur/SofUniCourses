using System.Collections.Generic;

namespace Problem_11._Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer()
        {
            BadgesCount = 0;
            Pokemons = new List<Pokemon>();
        }

        public int BadgesCount { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
