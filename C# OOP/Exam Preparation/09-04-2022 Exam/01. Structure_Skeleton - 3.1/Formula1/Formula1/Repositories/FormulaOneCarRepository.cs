namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => cars.AsReadOnly();

        public void Add(IFormulaOneCar model) => cars.Add(model);

        public IFormulaOneCar FindByName(string name) => cars.FirstOrDefault(car => car.Model == name);

        public bool Remove(IFormulaOneCar model) => cars.Remove(model);
    }
}
