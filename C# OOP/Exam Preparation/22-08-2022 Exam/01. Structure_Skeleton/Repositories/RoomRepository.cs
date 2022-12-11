using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model) => this.rooms.Add(model);

        public IReadOnlyCollection<IRoom> All() => this.rooms.AsReadOnly();

        public IRoom Select(string criteria)
        {
            var neededRoom = this.rooms.SingleOrDefault(room => room.GetType().Name == criteria);

            return neededRoom;
        }
    }
}

