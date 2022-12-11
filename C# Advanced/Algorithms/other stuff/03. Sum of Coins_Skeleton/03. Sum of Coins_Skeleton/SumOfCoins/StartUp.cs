namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var desiredSum = int.Parse(Console.ReadLine());

            var neededCoins = ChooseCoins(coins, desiredSum);

            var neededCoinsSum = neededCoins.Sum(coin => coin.Value);

            Console.WriteLine($"Number of coins to take: {neededCoinsSum}");

            foreach (var coin in neededCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sum = 0;
            coins = coins.OrderByDescending(coin => coin).ToList();
            var coinsIndex = 0;
            var neededCoins = new Dictionary<int, int>();

            while (sum != targetSum)
            {
                if (coinsIndex >= coins.Count) throw new InvalidOperationException();
                var currentCoin = coins[coinsIndex];
                if (sum + currentCoin <= targetSum) {
                    if (!neededCoins.ContainsKey(currentCoin)) neededCoins.Add(currentCoin, 0);
                    int numberOfCoinsNeeded = (targetSum - sum) / currentCoin;
                    neededCoins[currentCoin] += numberOfCoinsNeeded;
                    sum += currentCoin * numberOfCoinsNeeded;
                    coinsIndex += 1;
                }
                else
                {
                    coinsIndex += 1;
                }
            }

            return neededCoins.OrderByDescending(coin => coin.Key).ToDictionary(coin => coin.Key, coin => coin.Value);    
        }
    }
}