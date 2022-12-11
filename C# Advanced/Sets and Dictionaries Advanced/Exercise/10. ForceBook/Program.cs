using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var forceSides = new Dictionary<string, List<string>>();
            var forceUsers = new Dictionary<string, string>();

            while (!input.Contains("Lumpawaroo"))
            {
                var currentInput = input;
                input = Console.ReadLine();
                var forceSide = string.Empty;
                var forceUser = string.Empty;
                if (currentInput.Contains("|"))
                {
                    var _inputAsArr = currentInput.Split("|");
                    forceSide = _inputAsArr[0].Trim();
                    forceUser = _inputAsArr[1].Trim();
                    if (!forceSides.ContainsKey(forceSide)) forceSides.Add(forceSide, new List<string>());
                    if (!forceUsers.ContainsKey(forceUser)) {forceUsers.Add(forceUser, forceSide); forceSides[forceSide].Add(forceUser); }
                    continue;
                }
                var inputAsArr = currentInput.Split("->");
                forceUser = inputAsArr[0].Trim();
                forceSide = inputAsArr[1].Trim();
                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                if (!forceSides.ContainsKey(forceSide)) forceSides.Add(forceSide, new List<string>());
                if (!forceUsers.ContainsKey(forceUser))
                {
                    forceUsers.Add(forceUser, forceSide);
                    forceSides[forceSide].Add(forceUser);
                    continue;
                }
                var currentUserForceSide = forceUsers[forceUser];
                forceUsers[forceUser] = forceSide;
                forceSides[currentUserForceSide].Remove(forceUser);
                forceSides[forceSide].Add(forceUser);
            }

            var orderedSides = forceSides
                .OrderByDescending(side => side.Value.Count)
                .ThenBy(side => side.Key);

            foreach (var forceSide in orderedSides)
            {
                var output = SideOutput(forceSide.Value, forceSide.Key);
                if (output.Length > 0) Console.Write(output);
            }
        }

        static StringBuilder SideOutput(List<string> forceUsers, string side)
        {
            var finalOutput = new StringBuilder();
            if (forceUsers.Count == 0) return finalOutput;
            finalOutput.AppendLine($"Side: {side}, Members: {forceUsers.Count}");
            var orderedUsers = forceUsers.OrderBy(x => x).Select(forceUser => $"! {forceUser}");
            finalOutput.AppendLine(string.Join("\n", orderedUsers));
            return finalOutput;
        }
    }
}
