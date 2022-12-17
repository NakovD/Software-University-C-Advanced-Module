using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private static decimal price = 3.5M;

        private static double milliliters = 50;

        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }
    }
}
