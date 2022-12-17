using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DefiningClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var trainers = new List<Trainer>();
            ReadTrainers(trainers);
            ReadElements(trainers);

            var sortedTrainers = trainers
                .OrderByDescending(trainer => trainer.BadgesCount)
                .Select(trainer => $"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");

            Console.WriteLine(String.Join(Environment.NewLine, sortedTrainers));

        }

        public static void ReadTrainers(List<Trainer> trainers)
        {
            var line = Console.ReadLine();
            if (line.Contains("Tournament")) return;
            var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var trainerName = data[0];
            var pokemonName = data[1];
            var pokemonElement = data[2];
            var pokemontHealth = int.Parse(data[3]);
            Trainer trainer = null;
            var trainerExists = trainers.Any(trainer => trainer.Name == trainerName);
            if (trainerExists) trainer = trainers.Find(trainer => trainer.Name == trainerName); 
            else trainer = trainer = new Trainer(trainerName);
            var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemontHealth);
            trainer.Pokemons.Add(newPokemon);
            if (!trainerExists) trainers.Add(trainer);
            ReadTrainers(trainers);
        }

        public static void ReadElements(List<Trainer> trainers)
        {
            var element = Console.ReadLine();
            if (element == "End") return;
            var trainersToReceiveBadge = trainers
                .Where(trainer => trainer.Pokemons.Any(pokemon => pokemon.Element == element)).ToList();
            trainersToReceiveBadge.ForEach(trainer => trainer.BadgesCount += 1);

            var otherToReceiveDamage = trainers
                .Except(trainersToReceiveBadge)
                .ToList();

            otherToReceiveDamage.ForEach(trainer => trainer.Pokemons.ForEach(pokemon => pokemon.Health -= 10));

            trainers.ForEach(trainer => trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0));

            ReadElements(trainers);
        }

    }
}
