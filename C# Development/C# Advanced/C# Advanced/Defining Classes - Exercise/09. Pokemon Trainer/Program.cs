namespace Problem_11._Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament") break;

                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string trainerName = token[0];
                string pokemonName = token[1];
                string pokemonElement = token[2];
                int pokemonHealth = int.Parse(token[3]);

                var currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer());
                }
                trainers[trainerName].Pokemons.Add(currPokemon);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string element = input;

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Value.BadgesCount++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        if (trainer.Value.Pokemons.Any(p => p.Health <= 0))
                        {
                            trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.BadgesCount))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.BadgesCount} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
