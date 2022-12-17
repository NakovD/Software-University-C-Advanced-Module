﻿namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double defaultPrice = 4.00;

        public Gingerbread(string delicacyName) : base(delicacyName, defaultPrice)
        {
        }
    }
}
