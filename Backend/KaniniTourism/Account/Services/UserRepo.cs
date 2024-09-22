using AccountAPI.Interfaces;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AccountAPI.Services
{
    public class UserRepo:IRepo<User,string>
    {
        private readonly Context _context;
        public UserRepo(Context context)
        {
            _context = context;
        }

        public async Task<User?> Add(User item)
        {
            var user_mail =_context.Users.SingleOrDefault(u => u.Email == item.Email);
            if(user_mail == null)
            {
                try
                {
                    _context.Users.Add(item);
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

        public async Task<User?> Delete(string id)
        {
            try
            {
                var user = await Get(id);
                if(user != null)
                {
                    _context.Users.Remove(user);
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

        public async Task<User?> Get(string id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == id);
                if(user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public async Task<ICollection<User>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
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

        public async Task<User?> Update(User item)
        {
            var user = _context.Users.SingleOrDefault(u=> u.Email == item.Email);
            if (user != null)
            {
                try
                {
                    user.Email = item.Email;
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
