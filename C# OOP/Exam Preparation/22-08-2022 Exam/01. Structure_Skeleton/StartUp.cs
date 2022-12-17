namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Rooms;
    using System;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Don't forget to comment out the commented code lines in the Engine class!
            //IEngine engine = new Engine();
            //engine.Run();
            var someHotel = new Hotel("Some hotel", 5);
            var someRoom = new Studio();
            someRoom.SetPrice(5);
            someHotel.Bookings.AddNew(new Booking(someRoom, 1, 1, 0, 100));
            var someth = someHotel.Bookings.Select("100");
            
            Console.WriteLine(someth.BookingSummary());
        }
    }
}
