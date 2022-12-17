using BookingApp.Repositories.Contracts;
using BookingApp.Models.Bookings.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public IBooking Select(string criteria)
        {
            var neededBooking = this.bookings.SingleOrDefault(booking => booking.BookingNumber.ToString() == criteria);

            return neededBooking;
        }

        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.bookings;
        }
    }
}
