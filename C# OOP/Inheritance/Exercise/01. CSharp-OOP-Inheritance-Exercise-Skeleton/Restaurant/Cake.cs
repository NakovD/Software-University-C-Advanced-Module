using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private static decimal price = 5;

        private static double grams = 250;

        private static double calories = 1000;
        public Cake(string name) : base(name, price, grams, calories)
        {
        }
    }
}
