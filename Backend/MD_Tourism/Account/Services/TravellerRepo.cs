using AccountAPI.Interfaces;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountAPI.Services
{
    public class TravellerRepo:IRepo<Traveller,string>
    {
        private readonly Context _context;
        public TravellerRepo(Context context)
        {
            _context = context;
        }

        public async Task<Traveller?> Add(Traveller item)
        {
            var traveller_mail = _context.Travellers.SingleOrDefault(t=>t.Email == item.Email);
            if (traveller_mail == null)
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

        public async Task<Traveller?> Delete(string id)
        {
            try
            {
                var traveller = await Get(id);
                if (traveller != null)
                {
                    _context.Travellers.Remove(traveller);
                    await _context.SaveChangesAsync();
                    return traveller;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Traveller?> Get(string id)
        {
            try
            {
                var traveller = await _context.Travellers.SingleOrDefaultAsync(t => t.Email == id);
                if(traveller == null)
                {
                    return null;
                }
                return traveller;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Traveller>?> GetAll()
        {
            try
            {
                var travellers = await _context.Travellers.ToListAsync();
                if (travellers != null)
                {
                    return travellers;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Traveller?> Update(Traveller item)
        {
            var traveller = _context.Travellers.SingleOrDefault(t => t.Email == item.Email);
            if(traveller != null)
            {
                try
                {
                    traveller.Name = item.Name;
                    traveller.DateOfBirth = item.DateOfBirth;
                    traveller.Phone = item.Phone;
                    traveller.Address = item.Address;
                    traveller.Gender = traveller.Gender;
                    await _context.SaveChangesAsync();
                    return traveller;
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
