using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {

        public string RandomString()
        {
            var random = new Random();
            var randomIndex = random.Next(this.Count);
            var removedElement = this[randomIndex];
            this.RemoveAt(randomIndex);
            return removedElement;
        }
    }
}
