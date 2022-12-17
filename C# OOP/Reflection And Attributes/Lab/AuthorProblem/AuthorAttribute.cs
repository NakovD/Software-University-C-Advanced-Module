using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]

    public class AuthorAttribute : Attribute
    {
        public string Name { get; private set; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
}
