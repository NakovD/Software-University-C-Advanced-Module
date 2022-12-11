using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string BrowseWeb(string site)
        {
            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
