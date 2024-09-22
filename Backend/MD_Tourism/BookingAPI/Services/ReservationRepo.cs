using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Services
{
    public class ReservationRepo : IRepo<Reservation, int>
    {
        private readonly Context _context;
        public ReservationRepo(Context context)
        {
            _context = context;
        }
        public async Task<Reservation?> Add(Reservation item)
        {
            try
            {
                _context.Reservations.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Reservation?> Delete(int id)
        {
            try
            {
                var res = await Get(id);
                if (res != null)
                {
                    _context.Reservations.Remove(res);
                    await _context.SaveChangesAsync();
                    return res;
                }
                return null;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Reservation?> Get(int id)
        {
            try
            {
                var res = await _context.Reservations.SingleOrDefaultAsync(u => u.ReservationId == id);
                if (res == null)
                {
                    return null;
                }
                return res;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Reservation>?> GetAll()
        {
            try
            {
                var res = await _context.Reservations.ToListAsync();
                if (res != null)
                {
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Reservation?> Update(Reservation item)
        {
            var res = _context.Reservations.SingleOrDefault(u => u.ReservationId == item.ReservationId);
            if (res != null)
            {
                try
                {
                    res.travellerEmail = item.travellerEmail;
                    res.TravellerCount=item.TravellerCount;
                    res.AgencyId = item.AgencyId;
                    res.availableCount = item.availableCount;
                    res.PickUp = item.PickUp;
                    res.Drop = item.Drop;
                    res.packageId = item.packageId;
                    res.Type = item.Type;
                    await _context.SaveChangesAsync();
                    return res;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        
        }
    }
}
