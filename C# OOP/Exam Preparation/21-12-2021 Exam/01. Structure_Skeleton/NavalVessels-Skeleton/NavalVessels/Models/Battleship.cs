namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private static readonly double defaultArmor = 300;

        private double baseSpeed;

        private double baseWeaponCaliber;

        public bool SonarMode { get; private set; }

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmor)
        {
            baseSpeed = speed;
            baseWeaponCaliber = mainWeaponCaliber;
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;

            if (SonarMode)
            {
                MainWeaponCaliber = baseWeaponCaliber + 40;
                Speed =  baseSpeed - 5;
            }
            else
            {
                MainWeaponCaliber = baseWeaponCaliber - 40;
                if (MainWeaponCaliber < 0) MainWeaponCaliber = 0;
                Speed = baseSpeed + 5;
            }
        }

        public override void RepairVessel() => ArmorThickness = defaultArmor;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var sonarModeStatus = SonarMode ? "ON" : "OFF";
            var sonarModeString = $" *Sonar mode: {sonarModeStatus}";
            sb.AppendLine(sonarModeString);

            return sb.ToString().Trim();
        }
    }
}
