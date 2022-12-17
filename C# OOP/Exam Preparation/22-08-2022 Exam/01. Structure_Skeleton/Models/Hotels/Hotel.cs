using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                fullName = value;
            }
        }

        private int category;

        public int Category
        {
            get { return category; }
            set
            {
                if (value < 1 || value > 5) throw new ArgumentException(ExceptionMessages.InvalidCategory);
                category = value;
            }
        }

        public double Turnover { get => Math.Round(Bookings.All().Sum(booking => booking.ResidenceDuration * booking.Room.PricePerNight), 2); }

        public IRepository<IRoom> Rooms { get; set; }

        public IRepository<IBooking> Bookings { get; set; }


        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }
    }
}
