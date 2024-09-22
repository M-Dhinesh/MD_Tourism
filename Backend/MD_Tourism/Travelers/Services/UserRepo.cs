using Travelers.Interfaces;
using Travelers.Models;
using Microsoft.EntityFrameworkCore;

namespace Travelers.Services
{
    public class UserRepo : IRepo<TravelerUser, int>
    {
        private readonly Context _context;
        public UserRepo(Context context)
        {
            _context = context;

        }
        public async Task<TravelerUser?> Add(TravelerUser item)
        {
            var user_id = _context.TravelUsers.SingleOrDefault(u => u.UserId == item.UserId);
            if (user_id == null)
            {
                try
                {
                    _context.TravelUsers.Add(item);
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

        public async Task<TravelerUser?> Delete(int id)
        {
            try
            {
                var user = await Get(id);
                if (user != null)
                {
                    _context.TravelUsers.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<TravelerUser?> Get(int id)
        {
            try
            {
                var user = await _context.TravelUsers.SingleOrDefaultAsync(u => u.UserId == id);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<TravelerUser?> Get(string email)
        {
            try
            {
                var user = await _context.TravelUsers.SingleOrDefaultAsync(u => u.EmailId == email);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<ICollection<TravelerUser>?> GetAll()
        {
            try
            {
                var users = await _context.TravelUsers.ToListAsync();
                if (users != null)
                {
                    return users;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<TravelerUser?> Update(TravelerUser item)
        {
            var user = _context.TravelUsers.SingleOrDefault(u => u.UserId == item.UserId);
            if (user != null)
            {
                try
                {
                    user.EmailId = item.EmailId;
                    await _context.SaveChangesAsync();
                    return user;

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
