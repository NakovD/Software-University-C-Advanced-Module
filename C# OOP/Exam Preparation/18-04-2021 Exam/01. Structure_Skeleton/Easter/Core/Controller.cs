namespace Easter.Core
{
    using Easter.Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Workshops;
    using Easter.Repositories;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunnies;

        private EggRepository eggs;

        private Workshop workshop;

        private int coloredEggs = 0;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == bunnyType);
            if (type == null) throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);

            IBunny bunny;

            if (bunnyType == "HappyBunny") bunny = new HappyBunny(bunnyName);
            else bunny = new SleepyBunny(bunnyName);

            bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var neededBunny = bunnies.FindByName(bunnyName);
            if (neededBunny == null) throw new InvalidOperationException(ExceptionMessages.InexistentBunny);

            var dye = new Dye(power);

            neededBunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggs.FindByName(eggName);

            var validBunnies = bunnies.Models.Where(b => b.Energy >= 50);

            if (!validBunnies.Any()) throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);

            validBunnies = validBunnies.OrderByDescending(b => b.Energy);

            foreach (var bunny in validBunnies)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0) bunnies.Remove(bunny);
                if (egg.IsDone()) break;
            }

            var result = egg.IsDone() ? OutputMessages.EggIsDone : OutputMessages.EggIsNotDone;

            coloredEggs = egg.IsDone() ? coloredEggs + 1 : coloredEggs;

            return string.Format(result, eggName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            var bunniesData = string.Join(Environment.NewLine, bunnies.Models);

            sb.AppendLine(bunniesData);

            return sb.ToString().Trim();
        }
    }
}
