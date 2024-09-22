using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Services
{
    public class PassengersRepo : IRepo<Passengers, int>
        {
            private readonly Context _context;
            public PassengersRepo(Context context)
            {
                _context = context;
            }
            public async Task<Passengers?> Add(Passengers item)
            {
                var user = _context.Tour_Travellers.SingleOrDefault(u => u.PassengersId == item.PassengersId);
                if (user == null)
                {
                    try
                    {
                        _context.Tour_Travellers.Add(item);
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

            public async Task<Passengers?> Delete(int id)
            {
                try
                {
                    var user = await Get(id);
                    if (user != null)
                    {
                        _context.Tour_Travellers.Remove(user);
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

            public async Task<Passengers?> Get(int id)
            {
                try
                {
                    var user = await _context.Tour_Travellers.SingleOrDefaultAsync(u => u.PassengersId == id);
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

            public async Task<ICollection<Passengers>?> GetAll()
            {
                try
                {
                    var users = await _context.Tour_Travellers.ToListAsync();
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

            public async Task<Passengers?> Update(Passengers item)
            {
                var user = _context.Tour_Travellers.SingleOrDefault(u => u.PassengersId == item.PassengersId);
                if (user != null)
                {
                    try
                    {
                        user.Name = item.Name;
                        user.age = item.age;
                        user.packageId = item.packageId;
                        user.travellerEmail = item.travellerEmail;
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