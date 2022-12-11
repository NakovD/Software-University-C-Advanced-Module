namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                name = value;
            }
        }

        private int capacity;

        public int Capacity { get => capacity; private set => capacity = value; }

        public int Comfort => Decorations.Sum(d => d.Comfort);

        private ICollection<IDecoration> decorations;

        public ICollection<IDecoration> Decorations => decorations;

        private ICollection<IFish> fish;

        public ICollection<IFish> Fish => fish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            fish = new List<IFish>();
            decorations = new List<IDecoration>();
        }

        public void AddDecoration(IDecoration decoration) => Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity) throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");

            var fishAsString = fish.Any() ? string.Join(", ", Fish.Select(f => f.Name)) : "none";
            sb.AppendLine($"Fish: {fishAsString}");
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish) => Fish.Remove(fish);

    }
}
