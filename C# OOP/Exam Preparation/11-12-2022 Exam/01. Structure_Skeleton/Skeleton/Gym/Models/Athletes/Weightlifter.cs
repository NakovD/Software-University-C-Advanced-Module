namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;
    using System;

    public class Weightlifter : Athlete
    {
        private const int initialStamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, initialStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
