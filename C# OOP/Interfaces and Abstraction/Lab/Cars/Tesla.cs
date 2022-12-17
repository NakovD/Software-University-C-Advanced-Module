using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public string Model { get; set; }

        public string Color { get; set; }

        public int Battery { get; set; }

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model} with {Battery} Batteries";
        }
    }
}
