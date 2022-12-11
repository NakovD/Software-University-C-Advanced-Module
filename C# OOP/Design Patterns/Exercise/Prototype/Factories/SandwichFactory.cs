namespace Prototype.Factories
{
    using Models;

    using System.Collections.Generic;

    public class SandwichFactory
    {
        private Dictionary<string, Sandwich> sandwiches;

        public SandwichFactory()
        {
            sandwiches = new Dictionary<string, Sandwich>();
        }

        public Sandwich this[string index]
        {
            get => sandwiches[index];

            set => sandwiches[index] = value;
        }
    }
}
