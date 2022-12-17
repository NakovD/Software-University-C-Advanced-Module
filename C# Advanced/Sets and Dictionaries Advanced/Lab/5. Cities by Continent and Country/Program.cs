using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLines = int.Parse(Console.ReadLine());
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputLines; i++)
            {
                var currentLine = Console.ReadLine().Split(" ");
                var continent = currentLine[0];
                var country = currentLine[1];
                var city = currentLine[2];
                if (!continents.ContainsKey(continent))
                {
                    var countries = new Dictionary<string, List<string>>();
                    var cities = new List<string>() { city };
                    countries.Add(country, cities);
                    continents.Add(continent, countries);
                    continue;
                }

                if (continents[continent].ContainsKey(country))
                {
                    continents[continent][country].Add(city);
                    continue;
                }
                var newCountryCities = new List<string>() { city };
                var newCountry = new Dictionary<string, List<string>>();
                newCountry.Add(country, newCountryCities);
                continents[continent].Add(country, newCountryCities);
            }

            foreach (var continent in continents)
            {
                var countriesWithCities = continent.Value.Select(country => $"  {country.Key} -> {string.Join(", ", country.Value)}");
                Console.WriteLine($"{continent.Key}:");
                Console.WriteLine(string.Join("\n", countriesWithCities));
            }
        }
    }
}
