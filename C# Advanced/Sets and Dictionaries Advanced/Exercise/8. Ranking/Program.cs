using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, User>();

            while (!input.Contains("end of contests"))
            {
                var _contestData = input.Split(":");
                input = Console.ReadLine();
                var contestName = _contestData[0].ToString();
                var contestPassword = _contestData[1].ToString();
                if (contests.ContainsKey(contestName)) continue;
                contests.Add(contestName, contestPassword);
            }

            input = Console.ReadLine();

            while (!input.Contains("end of submissions"))
            {
                var userData = input.Split("=>");
                input = Console.ReadLine();
                var contest = userData[0];
                var contestPassword = userData[1];
                var username = userData[2];
                var userpoints = int.Parse(userData[3]);
                if (!contests.ContainsKey(contest)) continue;
                if (contests[contest] != contestPassword) continue;

                if (users.ContainsKey(username))
                {
                    var currentUser = users[username];
                    var userContests = currentUser.Contests;
                    if (userContests.ContainsKey(contest))
                    {
                        var previousPoints = userContests[contest];
                        if (userpoints <= previousPoints) continue;
                        userContests[contest] = userpoints;
                        currentUser.TotalPoints += userpoints - previousPoints;
                        continue;
                    }
                    userContests.Add(contest, userpoints);
                    currentUser.TotalPoints += userpoints;
                    continue;
                }
                AddNewUser(users, contest, userpoints, username);
            }

            var orderedUsersByPoints = users.OrderByDescending(user => user.Value.TotalPoints).ToDictionary(u => u.Key, u => u.Value);

            PrintUserWithMaxPoints(orderedUsersByPoints);
            Console.WriteLine("Ranking:");
            PrintOtherUsers(orderedUsersByPoints);
        }

        static void PrintOtherUsers(Dictionary<string, User> orderedUsersByPoints)
        {
            var allUsersSortedByBame = orderedUsersByPoints.OrderBy(user => user.Key).ToDictionary(u => u.Key, u => u.Value);

            foreach (var user in allUsersSortedByBame)
            {
                Console.WriteLine(user.Key);
                var contests = user.Value.Contests.OrderByDescending(contest => contest.Value).Select(contest => $"#  {contest.Key} -> {contest.Value}");
                Console.WriteLine(string.Join("\n", contests));

            }
        }

        static void AddNewUser(Dictionary<string, User> users, string contest, int userpoints, string username)
        {
            var newUser = new User();
            newUser.Contests.Add(contest, userpoints);
            newUser.TotalPoints = userpoints;
            users.Add(username, newUser);
        }

        static void PrintUserWithMaxPoints(Dictionary<string, User> orderedUsersByPoints)
        {
            var bestUser = orderedUsersByPoints.First();
            Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value.TotalPoints} points.");
        }
    }

    class User
    {
        public Dictionary<string, int> Contests { get; set; }
        public int TotalPoints { get; set; }

        public User()
        {
            this.Contests = new Dictionary<string, int>();
            this.TotalPoints = 0;
        }
    }
}
