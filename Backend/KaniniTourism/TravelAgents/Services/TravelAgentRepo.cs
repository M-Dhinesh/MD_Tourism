using Microsoft.EntityFrameworkCore;
using TravelAgents.Interfaces;
using TravelAgents.Models;

namespace TravelAgents.Services
{
    public class TravelAgentRepo : IRepo<TravelAgent, int>
    {
        private readonly Context _context;
        public TravelAgentRepo(Context context)
        {

            _context = context;

        }
        public async Task<TravelAgent?> Add(TravelAgent item)
        {
            var traveller_id = _context.TravelAgents.SingleOrDefault(p => p.AgencyID == item.AgencyID);
            if (traveller_id == null)
            {
                try
                {
                    _context.TravelAgents.Add(item);
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

        public async Task<TravelAgent?> Delete(int id)
        {
            try
            {
                var travelers = await Get(id);
                if (travelers != null)
                {
                    _context.TravelAgents.Remove(travelers);
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

        public async Task<TravelAgent?> Get(int id)
        {
            try
            {
                var travelers = await _context.TravelAgents.SingleOrDefaultAsync(i => i.AgencyID == id);
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

        public async Task<TravelAgent?> Get(string email)
        {
            try
            {
                var travelers = await _context.TravelAgents.SingleOrDefaultAsync(i => i.Email == email);
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

        public async Task<ICollection<TravelAgent>?> GetAll()
        {
            try
            {
                var travelers = await _context.TravelAgents.ToListAsync();
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


        public async Task<TravelAgent?> Update(TravelAgent item)
        {
            var travelers = _context.TravelAgents.SingleOrDefault(p => p.AgencyID == item.AgencyID);
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
