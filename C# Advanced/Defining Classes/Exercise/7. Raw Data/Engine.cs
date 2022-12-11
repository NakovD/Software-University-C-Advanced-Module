using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public double Speed { get; set; }

        public double Power { get; set; }

        public Engine(double speed, double power)
        {
            Speed = speed;
            Power = power;
        }
    }
}
