namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations;

        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == aquariumType);
            if (type == null) throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium") aquarium = new FreshwaterAquarium(aquariumName);
            else aquarium = new SaltwaterAquarium(aquariumName);

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == decorationType);
            if (type == null) throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            IDecoration decoration;

            if (decorationType == "Ornament") decoration = new Ornament();
            else decoration = new Plant();

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == fishType);
            if (type == null) throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            IFish fish;

            if (fishType == "FreshwaterFish") fish = new FreshwaterFish(fishName, fishSpecies, price);
            else fish = new SaltwaterFish(fishName, fishSpecies, price);

            var neededAquarium = aquariums.SingleOrDefault(a => a.Name == aquariumName);

            if (neededAquarium.GetType().Name == "FreshwaterAquarium" && fishType != "FreshwaterFish") return OutputMessages.UnsuitableWater;
            if (neededAquarium.GetType().Name == "SaltwaterAquarium" && fishType != "SaltwaterFish") return OutputMessages.UnsuitableWater;

            neededAquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var neededAquarium = aquariums.SingleOrDefault(a => a.Name == aquariumName);

            decimal sumOfDecorationsPrices = neededAquarium.Decorations.Sum(d => d.Price);

            decimal sumOfFishesPrices = neededAquarium.Fish.Sum(f => f.Price);

            decimal totalSum = sumOfDecorationsPrices + sumOfFishesPrices;

            return string.Format(OutputMessages.AquariumValue, aquariumName, Math.Round(totalSum, 2));
        }

        public string FeedFish(string aquariumName)
        {
            var neededAquarium = aquariums.SingleOrDefault(a => a.Name == aquariumName);

            neededAquarium.Feed();

            return string.Format(OutputMessages.FishFed, neededAquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var neededDecoration = decorations.FindByType(decorationType);
            if (neededDecoration == null) throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));

            var neededAquarium = aquariums.SingleOrDefault(a => a.Name == aquariumName);

            neededAquarium.AddDecoration(neededDecoration);

            decorations.Remove(neededDecoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, aquariums.Select(a => a.GetInfo()));
        }
    }
}
