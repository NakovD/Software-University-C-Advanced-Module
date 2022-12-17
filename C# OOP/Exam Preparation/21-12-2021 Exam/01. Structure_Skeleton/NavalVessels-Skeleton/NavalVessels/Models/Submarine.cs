namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private static readonly double defaultArmor = 200;

        private double baseSpeed;

        private double baseWeaponCaliber;

        public bool SubmergeMode { get; private set; }

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmor)
        {
            baseSpeed = speed;
            baseWeaponCaliber = mainWeaponCaliber;
        }

        public override void RepairVessel() => ArmorThickness = defaultArmor;

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber = baseWeaponCaliber + 40;
                Speed = baseSpeed - 4;
            }
            else
            {
                MainWeaponCaliber = baseWeaponCaliber - 40;
                if (MainWeaponCaliber < 0) MainWeaponCaliber = 0;
                Speed = baseSpeed + 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var submergeModeStatus = SubmergeMode ? "ON" : "OFF";
            var submergeModeString = $" *Submerge mode: {submergeModeStatus}";
            sb.AppendLine(submergeModeString);

            return sb.ToString().Trim();
        }
    }
}
