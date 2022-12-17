using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public List<Player> Players { get; private set; }

        public int Count { get => this.Players.Count; }

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            this.Players = new List<Player>();
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position)) return "Invalid player's information.";

            if (this.OpenPositions == 0) return "There are no more open positions.";

            if (player.Rating < 80) return "Invalid player's rating.";

            this.OpenPositions -= 1;
            this.Players.Add(player);

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";

        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.Players.SingleOrDefault(player => player.Name == name);

            if (playerToRemove == null) return false;

            this.Players.Remove(playerToRemove);

            this.OpenPositions++;

            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            var removedPlayers = this.Players.RemoveAll(player => player.Position == position);

            this.OpenPositions += removedPlayers;

            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            var player = this.Players.SingleOrDefault(player => player.Name == name);

            if (player != null) player.Retired = true;

            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            var rewardedPlayers = this.Players.Where(player => player.Games >= games).ToList();

            return rewardedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            var playersThatAreNotRetired = this.Players
                .Where(player => player.Retired == false)
                .Select(player => $"{player}");

            var playersAsString = string.Join(Environment.NewLine, playersThatAreNotRetired);
            sb.AppendLine(playersAsString);

            return sb.ToString().Trim();
        }

    }
}
