using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int studioRoomCapacity = 4;

        public Studio() : base(studioRoomCapacity)
        {
        }
    }
}
