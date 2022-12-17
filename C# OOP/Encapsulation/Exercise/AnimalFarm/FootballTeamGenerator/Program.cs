using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        private static List<Team> teams = new List<Team>();
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    ExecuteCommand(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }

        private static void ExecuteCommand(string command)
        {
            var commandData = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
            var action = commandData[0].ToLower();

            string[] remaningData = commandData.Skip(1).ToArray();

            switch (action)
            {
                case "team":
                    CreateTeam(commandData[1]);
                    break;
                case "add":
                    AddPlayer(remaningData);
                    break;
                case "remove":
                    RemovePlayer(remaningData);
                    break;
                default:
                    PrintTeamRating(remaningData);
                    break;
            }
        }

        private static void PrintTeamRating(string[] data)
        {
            var teamName = data[0];
            var (doesTeamExist, team) = ValidateTeam(teamName);
            if (!doesTeamExist) throw new ArgumentException($"Team {teamName} does not exist.");
            Console.WriteLine($"{team.Name} - {team.Rating}");
        }

        private static void RemovePlayer(string[] data)
        {
            var teamName = data[0];
            var playerName = data[1];
            var (doesTeamExist, neededTeam) = ValidateTeam(teamName);
            if (!doesTeamExist) return;
            neededTeam.RemovePlayer(playerName);
        }

        private static void AddPlayer(string[] data)
        {
            var teamName = data[0];
            var (doesTeamExist, neededTeam) = ValidateTeam(teamName);
            if (!doesTeamExist) throw new ArgumentException($"Team {teamName} does not exist.");
            var playerName = data[1];
            var playerEndurance = int.Parse(data[2]);
            var playerSprint = int.Parse(data[3]);
            var playerDribble = int.Parse(data[4]);
            var playerPassing = int.Parse(data[5]);
            var playerShooting = int.Parse(data[6]);
            var player = new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
            neededTeam.AddPlayer(player);
        }

        private static void CreateTeam(string teamName)
        {
            var doesTeamExist = teams.Any(team => team.Name == teamName);
            if (doesTeamExist) return;
            var newTeam = new Team(teamName);
            teams.Add(newTeam);
        }

        private static (bool, Team) ValidateTeam(string teamName)
        {
            var neededTeam = teams.SingleOrDefault(team => team.Name == teamName);
            if (neededTeam == null) return (false, null);

            return (true, neededTeam);
        }
    }
}
