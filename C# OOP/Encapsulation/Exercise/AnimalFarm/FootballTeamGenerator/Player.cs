using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int minStatValue = 0;

        private const int maxStatValue = 100;

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

        private int endurance;

        public int Endurance
        {
            get => endurance;
            set
            {
                if (value < minStatValue || value > maxStatValue) throw new ArgumentException($"{nameof(Endurance)} should be between {minStatValue} and {maxStatValue}.");
                endurance = value;
            }
        }

        private int sprint;

        public int Sprint
        {
            get => sprint;
            set
            {
                if (value < minStatValue || value > maxStatValue) throw new ArgumentException($"{nameof(Sprint)} should be between {minStatValue} and {maxStatValue}.");
                sprint = value;
            }
        }

        private int dribble;

        public int Dribble
        {
            get => dribble;
            set
            {
                if (value < minStatValue || value > maxStatValue) throw new ArgumentException($"{nameof(Dribble)} should be between {minStatValue} and {maxStatValue}.");
                dribble = value;
            }
        }

        private int passing;

        public int Passing
        {
            get => passing;
            set
            {
                if (value < minStatValue || value > maxStatValue) throw new ArgumentException($"{nameof(Passing)} should be between {minStatValue} and {maxStatValue}.");
                passing = value;
            }
        }

        private int shooting;

        public int Shooting
        {
            get => shooting;
            set
            {
                if (value < minStatValue || value > maxStatValue) throw new ArgumentException($"{nameof(Shooting)} should be between {minStatValue} and {maxStatValue}.");
                shooting = value;
            }
        }

        public double AverageSkill { get; private set; }

        public Player(string name,  int endurance, int sprint,  int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            AverageSkill = CalculateAverageSkill();
        }

        private double CalculateAverageSkill()
        {
            double sum = Endurance + Sprint + Dribble + Passing + Shooting;

            return sum / 5;
        }
    }
}
