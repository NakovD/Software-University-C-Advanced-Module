namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private VesselRepository vessels;

        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.SingleOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null) return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            var vessel = vessels.FindByName(selectedVesselName);
            if (vessel == null) return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            var vesselHasCaptain = vessel.Captain != null;
            if (vesselHasCaptain) return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var firstVessel = vessels.FindByName(attackingVesselName);
            if (firstVessel == null) return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            var secondVessel = vessels.FindByName(defendingVesselName);
            if (secondVessel == null) return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (firstVessel.ArmorThickness == 0) return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (secondVessel.ArmorThickness == 0) return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            firstVessel.Attack(secondVessel);
            firstVessel.Captain.IncreaseCombatExperience();
            secondVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, secondVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.SingleOrDefault(c => c.FullName == captainFullName);
            //if (captain == null) return string.Format(OutputMessages.CaptainNotFound, captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            var captainExist = captains.Any(c => c.FullName == fullName);
            if (captainExist) return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            ICaptain captain = new Captain(fullName);

            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vesselExist = vessels.FindByName(name) != null;
            if (vesselExist) return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);

            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == vesselType);
            if (type == null) return string.Format(OutputMessages.InvalidVesselType);

            IVessel vessel;

            try
            {
                vessel = Activator.CreateInstance(type, name, mainWeaponCaliber, speed) as IVessel;
            }
            catch (TargetInvocationException ex)
            {

                throw ex.InnerException;
            }

            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null) return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null) return string.Format(OutputMessages.VesselNotFound, vesselName);

            var isBattleShip = vessel.GetType() == typeof(Battleship);

            if (isBattleShip)
            {
                var battleShip = vessel as Battleship;
                battleShip.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            var submarine = vessel as Submarine;
            submarine.ToggleSubmergeMode();
            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            //if (vessel == null) return string.Format(OutputMessages.VesselNotFound, vesselName);

            return vessel.ToString();
        }
    }
}
