using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _whiteTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var _greyTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var whiteTiles = new Stack<int>(_whiteTiles);
            var greyTiles = new Queue<int>(_greyTiles);

            var locations = new Dictionary<string, int>()
            {
                { "Sink" , 0 },
                { "Oven" , 0 },
                { "Countertop" , 0 },
                { "Wall" , 0 },
                { "Floor" , 0 },
            };

            while (whiteTiles.Any() && greyTiles.Any())
            {
                var whiteTile = whiteTiles.Peek();
                var greyTile = greyTiles.Peek();
                if (whiteTile != greyTile) { DecreaseTiles(ref whiteTiles, greyTiles); continue; }
                var sum = whiteTile + greyTile;
                var location = GetLocation(sum);
                locations[location] += 1;
                whiteTiles.Pop();
                greyTiles.Dequeue();
            }

            var whiteTilesAmount = whiteTiles.Any() ? string.Join(", ", whiteTiles) : "none";
            var greyTilesAmount = greyTiles.Any() ? string.Join(", ", greyTiles) : "none";

            Console.WriteLine($"White tiles left: {whiteTilesAmount}");
            Console.WriteLine($"Grey tiles left: {greyTilesAmount}");

            var orderedLocations = locations
                .Where(location => location.Value > 0)
                .OrderByDescending(location => location.Value)
                .ThenBy(location => location.Key).Select(location => $"{location.Key}: {location.Value}");

            Console.WriteLine(String.Join(Environment.NewLine, orderedLocations));
        }

        public static void DecreaseTiles(ref Stack<int>  whiteTiles,  Queue<int> greyTiles)
        {
            var lastWhiteTile = whiteTiles.Peek();
            var tilesAsArray = whiteTiles.ToArray();
            tilesAsArray[0] = lastWhiteTile / 2;
            whiteTiles = new Stack<int>(tilesAsArray.Reverse());
            var lastGreyTile = greyTiles.Dequeue();
            greyTiles.Enqueue(lastGreyTile);
        }

        public static string GetLocation(int sum)
        {
            var location = string.Empty;

            switch (sum)
            {
                case 40: location = "Sink";
                    break;
                case 50: location = "Oven";
                    break;
                case 60: location = "Countertop";
                    break;
                case 70: location = "Wall";
                    break;
                default: location = "Floor";
                    break;
            }

            return location;
        }
    }
}
