using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Robot : ICitizen
    {
        public string Model { get; set; }

        public long Id { get; set; }

        public Robot(string model, long id)
        {
            Model = model;
            Id = id;
        }
    }
}
