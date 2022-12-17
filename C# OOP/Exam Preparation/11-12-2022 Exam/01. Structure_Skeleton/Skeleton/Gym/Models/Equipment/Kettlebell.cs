namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double kettlebellWeight = 10_000;

        private const decimal kettlebellPrice = 80;    
        public Kettlebell() : base(kettlebellWeight, kettlebellPrice)
        {
        }
    }
}
