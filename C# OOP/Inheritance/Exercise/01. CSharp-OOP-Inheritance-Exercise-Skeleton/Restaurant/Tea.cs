using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Restaurant
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }
    }
}
