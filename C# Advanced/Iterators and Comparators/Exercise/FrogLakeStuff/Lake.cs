using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FrogLakeStuff
{
    public class Lake : IEnumerable<int>
    {
        public List<int> Stones { get; set; }

        public Lake(List<int> stones)
        {
            Stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
