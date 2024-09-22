using BookingAPI.Interfaces;
using BookingAPI.Models;

namespace BookingAPI.Services
{
    public class ManageReservationService : IManageBooking
    {
        private readonly IRepo<Reservation,int> _reservationRepo;
        private readonly IRepo<Passengers, int> _passengers;

        public ManageReservationService(IRepo<Reservation, int> reservationRepo,IRepo<Passengers,int> passengers)
        {
            _reservationRepo = reservationRepo;
            _passengers = passengers;
        }

        public async Task<Reservation> AddReseration(Reservation reservation)
        {
            try
            {
                if (reservation.Type == "Public" || reservation.Type == "public")
                {
                
                    if(reservation.availableCount>0 && reservation.availableCount >= reservation.TravellerCount)
                    {
                        var res = await _reservationRepo.Add(reservation);
                        if (res != null)
                            return res;
                        return null;
                    }
                    return null;
                }
                var res1 = await _reservationRepo.Add(reservation);
                if (res1 != null) return res1;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ICollection<Passengers>> GetGuestsByTravellerEmail(string id)
        {
            try
            {
                var guests = await _passengers.GetAll();
                if (guests == null)
                {
                    return new List<Passengers>();
                }

                return guests.Where(g => g.travellerEmail == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Reservation>> GetReservationByPackageId(int id)
        {
            try
            {
                var reservations = await _reservationRepo.GetAll();
                if (reservations == null)
                {
                    return new List<Reservation>();
                }

                return reservations.Where(r => r.packageId == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Reservation>> GetReservationByTravellerEmail(string id)
        {
            try
            {
                var reservations = await _reservationRepo.GetAll();
                if (reservations == null)
                {
                    return new List<Reservation>();
                }

                return reservations.Where(r => r.travellerEmail == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        


    }
}
