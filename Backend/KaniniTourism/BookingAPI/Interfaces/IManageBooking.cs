using BookingAPI.Models;

namespace BookingAPI.Interfaces
{
    public interface IManageBooking
    { 
        public Task<ICollection<Reservation>> GetReservationByPackageId(int id);
        public Task<ICollection<Reservation>> GetReservationByTravellerEmail(string id);
        public Task<ICollection<Passengers>> GetGuestsByTravellerEmail(string id);
        public Task<Reservation> AddReseration(Reservation reservation);
    }
}
