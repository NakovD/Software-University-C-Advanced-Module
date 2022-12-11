namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int initialEnergy = 50;

        public SleepyBunny(string name) : base(name, initialEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= 5;
        }
    }
}
