using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0 ? true : false;

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }

            return this;
        }
    }
}
