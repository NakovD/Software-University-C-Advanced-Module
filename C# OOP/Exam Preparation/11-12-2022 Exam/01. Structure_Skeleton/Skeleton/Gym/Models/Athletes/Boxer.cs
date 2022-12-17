namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;
    using System;

    public class Boxer : Athlete
    {
        private const int initialStamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, initialStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += 15;

            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
