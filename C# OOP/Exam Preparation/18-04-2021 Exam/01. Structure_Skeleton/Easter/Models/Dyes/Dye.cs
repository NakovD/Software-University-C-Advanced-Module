namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;

    public class Dye : IDye
    {
        private int power;
        public int Power
        {
            get => power;

            private set
            {
                power = value;
                if (power < 0) power = 0;
            }
        }

        public Dye(int power)
        {
            Power = power;
        }

        public bool IsFinished() => Power == 0 ? true : false;

        public void Use() => Power -= 10;
    }
}
