namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int boxingGymCapacity = 15;

        public BoxingGym(string name) : base(name, boxingGymCapacity)
        {
        }
    }
}
