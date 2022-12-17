namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private CarRepository cars;

        private RacerRepository racers;

        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            var carType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (carType == null) throw new ArgumentException(ExceptionMessages.InvalidCarType);

            ICar newCar;

            if (type == "SuperCar") newCar = new SuperCar(make, model, VIN, horsePower);
            else newCar = new TunedCar(make, model, VIN, horsePower);

            cars.Add(newCar);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var neededCar = cars.FindBy(carVIN);
            if (neededCar == null) throw new ArgumentException(ExceptionMessages.CarCannotBeFound);

            var racerType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (racerType == null) throw new ArgumentException(ExceptionMessages.InvalidRacerType);

            IRacer racer;

            if (type == "ProfessionalRacer") racer = new ProfessionalRacer(username, neededCar);
            else racer = new StreetRacer(username, neededCar);

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            if (racerOne == null) throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            var racerTwo = racers.FindBy(racerTwoUsername);
            if (racerTwo == null) throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var orderedRacers = racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username);

            return string.Join(Environment.NewLine, orderedRacers);
        }
    }
}
