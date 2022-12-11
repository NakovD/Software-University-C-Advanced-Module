using System;

namespace StreetRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize Race
            Race race = new Race("RockPort Race", "Sprint", 1, 4, 150);

            //Initialize Car
            Car car = new Car("BMW", "320ci", "NFS2005", 150, 1450);

            //Print car
            Console.WriteLine(car.ToString());

            //Add car
            race.Add(car);

            //Remove car
            Console.WriteLine(race.Remove("NFS2005")); // True

            Car carOne = new Car("BMW", "320cd", "NFS2007", 150, 1350);
            Car carTwo = new Car("Audi", "A3", "NFS2004", 131, 1300);

            //Add cars
            race.Add(carOne);
            race.Add(carTwo);

            //GetMostPowerfulCar
            Console.WriteLine(race.GetMostPowerfulCar());

            //Print Race report
            Console.WriteLine(race.Report());

        }
    }
}
