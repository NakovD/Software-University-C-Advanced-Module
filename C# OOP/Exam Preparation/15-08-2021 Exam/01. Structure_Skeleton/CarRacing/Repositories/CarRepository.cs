namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            if (model == null) throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);

            cars.Add(model);
        }

        public ICar FindBy(string property) => cars.SingleOrDefault(car => car.VIN == property);

        public bool Remove(ICar model) => cars.Remove(model);
    }
}
