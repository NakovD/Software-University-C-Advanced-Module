namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipments;

        private List<IGym> gyms;

        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var typeAthlete = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == athleteType);
            if (typeAthlete == null) throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);

            var neededGym = gyms.SingleOrDefault(g => g.Name == gymName);

            if (typeAthlete.Name == typeof(Boxer).Name && neededGym.GetType().Name != typeof(BoxingGym).Name) return OutputMessages.InappropriateGym;

            if (typeAthlete.Name == typeof(Weightlifter).Name && neededGym.GetType().Name != typeof(WeightliftingGym).Name) return OutputMessages.InappropriateGym;

            IAthlete athlete;

            try
            {
                athlete = Activator.CreateInstance(typeAthlete, athleteName, motivation, numberOfMedals) as IAthlete;

            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            neededGym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            var typeEquipment = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == equipmentType);
            if (typeEquipment == null) throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);

            IEquipment equipment;

            try
            {
                equipment = Activator.CreateInstance(typeEquipment) as IEquipment;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            equipments.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            var typeGym = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == gymType);
            if (typeGym == null) throw new InvalidOperationException(ExceptionMessages.InvalidGymType);

            IGym gym;

            try
            {
                gym = Activator.CreateInstance(typeGym, gymName) as IGym;
            }
            catch (TargetInvocationException ex)
            {

                throw ex.InnerException;
            }

            gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var neededGym = gyms.SingleOrDefault(g => g.Name == gymName);

            var allEquipmentWeight = Math.Round(neededGym.EquipmentWeight, 2);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, allEquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var neededEquipmenty = equipments.Models.FirstOrDefault(eq => eq.GetType().Name == equipmentType);
            if (neededEquipmenty == null) throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));

            var neededGym = gyms.SingleOrDefault(g => g.Name == gymName);

            neededGym.AddEquipment(neededEquipmenty);

            equipments.Remove(neededEquipmenty);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report() => string.Join(Environment.NewLine, gyms.Select(g => g.GymInfo()));

        public string TrainAthletes(string gymName)
        {
            var neededGym = gyms.SingleOrDefault(g => g.Name == gymName);

            foreach (var item in neededGym.Athletes)
            {
                item.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, neededGym.Athletes.Count);
        }
    }
}
