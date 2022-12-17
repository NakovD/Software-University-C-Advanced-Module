using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;

        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("A name should not be empty");
                name = value;
            }
        }

        public int Rating { get => GetRating(); }

        public int NumberOfPlayers { get => this.players.Count; }

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var neededPlayer = players.SingleOrDefault(player => player.Name == playerName);
            if (neededPlayer == null) throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            players.Remove(neededPlayer);
        }

        private int GetRating()
        {
            var rating = players.Count > 0 ? players.Average(player => player.AverageSkill) : 0;
            return int.Parse(Math.Round(rating).ToString());
        }
    }
}
