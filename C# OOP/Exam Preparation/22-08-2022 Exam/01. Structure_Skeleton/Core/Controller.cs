using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel != null) return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);

            hotel = new Hotel(hotelName, category);

            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var validHotels = hotels.All().Where(hotel => hotel.Category == category);
            if (validHotels.Count() == 0) return string.Format(OutputMessages.CategoryInvalid, category);

            var orderedHotels = validHotels.OrderBy(hotel => hotel.FullName);
            var validRooms = new List<IRoom>();

            foreach (var hotel in orderedHotels)
            {
                var rooms = hotel.Rooms.All().Where(room => room.PricePerNight > 0);
                validRooms.AddRange(rooms);
            }

            var neededRoom = validRooms.OrderBy(room => room.BedCapacity).FirstOrDefault(room => room.BedCapacity >= adults + children);

            if (neededRoom == null) return string.Format(OutputMessages.RoomNotAppropriate);

            var neededHotel = validHotels.SingleOrDefault(hotel => hotel.Rooms.All().Contains(neededRoom));
            var bookingNumber = neededHotel.Bookings.All().Count + 1;
            var booking = new Booking(neededRoom, duration, adults, children, bookingNumber);

            neededHotel.Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, neededHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null) return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            var sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            var bookings = hotel.Bookings.All();

            sb.Append(Environment.NewLine);

            if (bookings.Count == 0)
            {
                sb.AppendLine("none");
            }

            foreach (var item in bookings)
            {
                sb.AppendLine(item.BookingSummary());
                sb.Append(Environment.NewLine);
            }


            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null) return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            var roomTypeIsValid = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(type => type.Name == roomTypeName);
            if (roomTypeIsValid == null) throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            var roomType = hotel.Rooms.Select(roomTypeName);
            if (roomType == null) return string.Format(OutputMessages.RoomTypeNotCreated);

            if (roomType.PricePerNight != 0) throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);

            roomType.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomType.GetType().Name, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null) return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            var roomTypeExist = hotel.Rooms.Select(roomTypeName);
            if (roomTypeExist != null) return string.Format(OutputMessages.RoomTypeAlreadyCreated);

            var roomType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(type => type.Name == roomTypeName);
            if (roomType == null) throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            var newRoomInstance = Activator.CreateInstance(roomType);

            hotel.Rooms.AddNew(newRoomInstance as IRoom);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
