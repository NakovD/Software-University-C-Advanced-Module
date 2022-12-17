namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; } = 1;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public void IncreaseEndurance()
        {
            if (EnduranceLevel == 20) throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);

            EnduranceLevel += 1;
        }
    }
}
