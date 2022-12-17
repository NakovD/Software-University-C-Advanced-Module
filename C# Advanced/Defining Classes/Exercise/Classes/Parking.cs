using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;

        public List<Car> Cars { get => this.cars; }

        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count { get => this.Cars.Count; }

        public string AddCar(Car Car)
        {
            var doesCarExist = this.Cars.Any(car => car.RegistrationNumber == Car.RegistrationNumber);

            if (doesCarExist) return "Car with that registration number, already exists!";

            if (this.Cars.Count == this.capacity) return "Parking is full!";

            this.Cars.Add(Car);

            return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";

        }

        public string RemoveCar(string RegistrationNumber)
        {
            var doesCarExist = this.Cars.Any(car => car.RegistrationNumber == RegistrationNumber);

            if (!doesCarExist) return "Car with that registration number, doesn't exist!";

            this.Cars.Remove(this.Cars.Find(car => car.RegistrationNumber == RegistrationNumber));

            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            return this.Cars.FirstOrDefault(car => car.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            RegistrationNumbers.ForEach(regNumber => RemoveCar(regNumber));
        }
    }
}
