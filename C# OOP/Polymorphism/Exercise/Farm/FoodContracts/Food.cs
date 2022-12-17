using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.FoodContracts
{
    public abstract class Food
    {
        public int Quantity { get; protected set; }

        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
