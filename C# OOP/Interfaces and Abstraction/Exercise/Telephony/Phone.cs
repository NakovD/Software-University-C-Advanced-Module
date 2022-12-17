using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Phone : IStationaryPhone
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
