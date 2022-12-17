namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);

                name = value;
            }
        }

        private ICaptain captain;

        public ICaptain Captain
        {
            get => captain;

            set
            {
                if (value == null) throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);

                captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        private ICollection<string> targets;

        public ICollection<string> Targets => targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public void Attack(IVessel target)
        {
            if (target == null) throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0) target.ArmorThickness = 0;

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");

            var targetsAsString = targets.Any() ? string.Join(", ", Targets) : "None";
            sb.AppendLine($" *Targets: {targetsAsString}");

            return sb.ToString().Trim();
        }
    }
}
