namespace Formula1.Core
{
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Utilities;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;

        private RaceRepository raceRepository;

        private FormulaOneCarRepository carsRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carsRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null) throw new ArgumentException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            if (pilot.Car != null) throw new ArgumentException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            var car = carsRepository.FindByName(carModel);
            if (car == null) throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            pilot.AddCar(car);

            carsRepository.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            var pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot == null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            if (!pilot.CanRace) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            var pilotIsAlreadyInTheRace = race.Pilots.Any(p => p.FullName == pilotFullName);

            if (pilotIsAlreadyInTheRace) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            race.AddPilot(pilot);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = carsRepository.FindByName(model);
            if (car != null) throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));

            var carType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (carType == null) throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));

            IFormulaOneCar newCar;

            try
            {
                newCar = Activator.CreateInstance(carType, model, horsepower, engineDisplacement) as IFormulaOneCar;

            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            carsRepository.Add(newCar);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            var pilot = pilotRepository.FindByName(fullName);
            if (pilot != null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            var newPilot = new Pilot(fullName);

            pilotRepository.Add(newPilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = raceRepository.FindByName(raceName);
            if (race != null) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            var newRace = new Race(raceName, numberOfLaps);

            raceRepository.Add(newRace);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var orderedPilots = pilotRepository.Models.OrderByDescending(pilot => pilot.NumberOfWins);

            var asString = string.Join(Environment.NewLine, orderedPilots);

            return asString;
        }

        public string RaceReport()
        {
            var executedRaces = raceRepository.Models.Where(race => race.TookPlace).Select(race => race.RaceInfo());

            var racesInfo = string.Join(Environment.NewLine, executedRaces);

            return racesInfo;
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (race.Pilots.Count < 3) throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));

            if (race.TookPlace) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            var sortedRiders = race.Pilots.OrderByDescending(pilot => pilot.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            race.TookPlace = true;

            var firstPlace = sortedRiders[0];
            var secondPlace = sortedRiders[1];
            var thirdPlace = sortedRiders[2];

            firstPlace.WinRace();

            var sb = new StringBuilder();

            sb.AppendLine($"Pilot {firstPlace.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
