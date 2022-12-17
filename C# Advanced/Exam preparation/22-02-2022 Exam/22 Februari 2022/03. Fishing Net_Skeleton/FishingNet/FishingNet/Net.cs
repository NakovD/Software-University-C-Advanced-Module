using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.Fish.Count; }

        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public string AddFish(Fish fish)
        {
            var isFishValid = ValidateFish(fish);
            if (!isFishValid) return "Invalid fish.";
            if (this.Capacity == this.Fish.Count) return "Fishing net is full.";

            this.Fish.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ValidateFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType)) return false;
            if (fish.Weight <= 0 || fish.Length <= 0) return false;
            return true;
        }

        public bool ReleaseFish(double weight)
        {
            var neededFish = this.Fish.SingleOrDefault(fish => fish.Weight == weight);

            if (neededFish == null) return false;

            return this.Fish.Remove(neededFish);
        }

        public Fish GetFish(string fishType)
        {
            var neededFish = this.Fish.SingleOrDefault(fish => fish.FishType == fishType);

            return neededFish;
        }

        public Fish GetBiggestFish()
        {
            var neededFish = this.Fish.OrderByDescending(fish => fish.Length).Take(1).ToList()[0];

            return neededFish;
        }

        public string Report()
        {
            var sortedFishByLength = this.Fish.OrderByDescending(fish => fish.Length);
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            sb.AppendLine(string.Join(Environment.NewLine, sortedFishByLength));

            return sb.ToString().Trim();
        }
    }
}
