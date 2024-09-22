using Travelers.Interfaces;
using Travelers.Models;
using Microsoft.EntityFrameworkCore;

namespace Travelers.Services
{
    public class TravelersRepo : IRepo<Traveler, int>
    {
        private readonly Context _context;
        public TravelersRepo(Context context)
        {

            _context = context;

        }
        public async Task<Traveler?> Add(Traveler item)
        {
            var traveller_id = _context.Travellers.SingleOrDefault(p => p.TravellerId == item.TravellerId);
            if (traveller_id == null)
            {
                try
                {
                    _context.Travellers.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public async Task<Traveler?> Delete(int id)
        {
            try
            {
                var travelers = await Get(id);
                if (travelers != null)
                {
                    _context.Travellers.Remove(travelers);
                    await _context.SaveChangesAsync();
                    return travelers;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<Traveler?> Get(int id)
        {
            try
            {
                var travelers = await _context.Travellers.SingleOrDefaultAsync(i => i.TravellerId == id);
                if (travelers == null)
                {
                    return null;
                }
                return travelers;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Traveler?> Get(string email)
        {
            try
            {
                var travelers = await _context.Travellers.SingleOrDefaultAsync(i => i.Email == email);
                if (travelers == null)
                {
                    return null;
                }
                return travelers;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Traveler>?> GetAll()
        {
            try
            {
                var travelers = await _context.Travellers.ToListAsync();
                if (travelers != null)
                {
                    return travelers;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public async Task<Traveler?> Update(Traveler item)
        {
            var travelers = _context.Travellers.SingleOrDefault(p => p.TravellerId == item.TravellerId);
            if (travelers != null)
            {
                try
                {
                    travelers.Name = item.Name;
                    travelers.Address = item.Address;
                    travelers.Email = item.Email;
                    travelers.Phone = item.Phone;
                    travelers.Gender = item.Gender;
                    await _context.SaveChangesAsync();
                    return travelers;
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
