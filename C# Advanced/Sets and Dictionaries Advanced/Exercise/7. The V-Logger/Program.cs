using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var vloggers = new Dictionary<string, Vlogger>();

            while (!input.Contains("Statistics"))
            {
                var _input = input.Split(" ");
                input = Console.ReadLine();

                if (_input.Contains("joined"))
                {
                    var currentVlogger = _input[0];
                    AddVlogger(vloggers, currentVlogger);
                    continue;
                }

                var followingVlogger = _input[0];
                var followedVlogger = _input[2];
                FollowVlogger(vloggers, followingVlogger, followedVlogger);
            }

            var orderedVloggers = vloggers
                .OrderByDescending(vlogger => vlogger.Value.Followers.Count)
                .ThenBy(vlogger => vlogger.Value.Following.Count)
                .ToDictionary(v => v.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            PrintMostFamousVlogger(orderedVloggers);
            PrintOtherVloggers(orderedVloggers);
        }

        static void PrintOtherVloggers(Dictionary<string, Vlogger> orderedVloggers)
        {
            var otherVloggers = orderedVloggers.Skip(1);
            var otherVloggersAsString = otherVloggers
                .Select((vlogger, index) => $"{index + 2}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            Console.WriteLine(string.Join("\n", otherVloggersAsString));
        }

        static void PrintMostFamousVlogger(Dictionary<string, Vlogger> orderedVloggers)
        {
            var mostFamousOne = orderedVloggers.Take(1).ToArray()[0];
            var followers = mostFamousOne.Value.Followers
                .OrderBy(x => x)
                .Select(follower => $"*  {follower}");
            var followersAsString = string.Join("\n", followers);
            Console.WriteLine($"1. {mostFamousOne.Key} : {mostFamousOne.Value.Followers.Count} followers, {mostFamousOne.Value.Following.Count} following");
            Console.WriteLine(followersAsString);
        }

        static void FollowVlogger(Dictionary<string, Vlogger> vloggers, string followingVlogger, string followedVlogger)
        {
            if (!vloggers.ContainsKey(followedVlogger) || !vloggers.ContainsKey(followingVlogger)) return;
            if (followingVlogger == followedVlogger) return;
            var followersOfFollowedVlogger = vloggers[followedVlogger].Followers;
            if (followersOfFollowedVlogger.Contains(followingVlogger)) return;
            vloggers[followedVlogger].Followers.Add(followingVlogger);
            vloggers[followingVlogger].Following.Add(followedVlogger);
        }

        static void AddVlogger(Dictionary<string, Vlogger> vloggers, string newVlogger)
        {
            if (vloggers.ContainsKey(newVlogger)) return;
            var followers = new List<string>();
            var following = new List<string>();
            vloggers.Add(newVlogger, new Vlogger(newVlogger, followers, following));
        }

    }

    class Vlogger
    {
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public Vlogger(string name, List<string> followers, List<string> following)
        {
            this.Name = name;
            this.Followers = followers;
            this.Following = following;
        }
    }
}
