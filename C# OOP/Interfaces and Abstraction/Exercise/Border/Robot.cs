using System;
using System.Collections.Generic;
using System.Text;
using Border.Contracts;

namespace Border
{
    public class Robot : ICitizen
    {
        public string Model { get; set; }

        public string Id { get; private set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}
