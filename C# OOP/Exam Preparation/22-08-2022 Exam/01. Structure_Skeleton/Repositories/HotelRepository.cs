using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<IHotel> All()
        {
            throw new System.NotImplementedException();
        }

        public IHotel Select(string criteria)
        {
            throw new System.NotImplementedException();
        }

        //public void AddNew(IHotel model)
        //{
        //    this.hotels.Add(model);
        //}

        //public IReadOnlyCollection<IHotel> All()
        //{
        //    return this.hotels.AsReadOnly();
        //}

        //public IHotel Select(string criteria)
        //{
        //    var neededHotel = this.hotels.SingleOrDefault(hotel => hotel.FullName == criteria);

        //    return neededHotel;
        //}
    }
}
