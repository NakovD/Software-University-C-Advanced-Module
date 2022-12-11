using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class BookingAppTest
    {
        private Room room;

        [SetUp]
        public void Setup()
        {
            room = new Room(5, 5.5);
        }

        [Test]
        public void Test_RoomCtorValidArgs()
        {
            var expectedBedCapacity = 5;
            var expectedPrice = 5.5;

            Assert.IsTrue(expectedBedCapacity == room.BedCapacity);
            Assert.IsTrue(expectedPrice == room.PricePerNight);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(-10, 10)]
        [TestCase(10, 0)]
        [TestCase(10, -10)]
        public void Test_RoomCtorInvalidArgs(int bedCapacity, double price)
        {
            Assert.Throws<ArgumentException>(() => { room = new Room(bedCapacity, price); });
        }


        [Test]
        public void Test_BookingCtorValidArgs()
        {
            var room = new Room(1, 2);
            var booking = new Booking(105, room, 100);

            var expectingBookingNumber = 105;
            var expectingBookingRoom = room;
            var expectingDuration = 100;

            Assert.IsTrue(expectingBookingNumber == booking.BookingNumber);
            Assert.AreSame(expectingBookingRoom, booking.Room);
            Assert.IsTrue(expectingDuration == booking.ResidenceDuration);
        }

        [Test]
        public void Test_BookingCtorInvalidArgs()
        {

        }

        [Test]
        public void Test_HotelCtorValidArgs()
        {
            var expectedFullName = "Some name";
            var expectedCategory = 4;
            var hotel = new Hotel(expectedFullName, expectedCategory);

            Assert.IsTrue(expectedFullName == hotel.FullName);
            Assert.IsTrue(expectedCategory == hotel.Category);
            Assert.AreEqual(new List<Booking>(), hotel.Bookings);
            Assert.AreEqual(new List<Room>(), hotel.Rooms);
        }

        [Test]
        [TestCase("", 5)]
        [TestCase(" ", 5)]
        [TestCase(null, 5)]
        public void Test_HotelCtorInvalidName(string fullName, int category)
        {
            Assert.Throws<ArgumentNullException>(() => { var hotel = new Hotel(fullName, category); });
        }

        [Test]
        [TestCase("someName", 6)]
        [TestCase("someName", 0)]
        public void Test_HotelCtorInvalidCategory(string fullName, int category)
        {
            Assert.Throws<ArgumentException>(() => { var hotel = new Hotel(fullName, category); });

        }

        [Test]
        public void Test_HotelAddRoom()
        {
            var hotel = new Hotel("some Hotel", 3);

            hotel.AddRoom(room);

            Assert.AreEqual(hotel.Rooms, new List<Room>() { room });
        }

        [Test]
        [TestCase(0, 2, 3)]
        [TestCase(-5, 2, 3)]
        [TestCase(5, -5, 3)]
        [TestCase(5, 0, 0)]
        [TestCase(5, 0, -5)]
        public void Test_BookRoomThrows(int adults, int children, int residenceDuration)
        {
            var hotel = new Hotel("some name", 4);

            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(adults, children, residenceDuration, 100); });
        }

        [Test]
        public void Test_BookRoomCreatesBookings()
        {
            var hotel = new Hotel("some name", 4);
            var validRoom = new Room(6, 2);
            hotel.AddRoom(new Room(3, 5));
            hotel.AddRoom(new Room(2, 4));
            hotel.AddRoom(new Room(6, 2));

            hotel.BookRoom(3, 1, 3, 100);
            var expectedTurnOver = 3 * 2;

            var expectedBookings = new List<Booking>() { new Booking(1, validRoom, 3) };

            Assert.IsTrue(expectedTurnOver == hotel.Turnover);
            Assert.AreEqual(expectedBookings.Count, hotel.Bookings.Count);
        }
    }
}