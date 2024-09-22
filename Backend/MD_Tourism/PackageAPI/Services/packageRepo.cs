using Microsoft.EntityFrameworkCore;
using PackageAPI.Interfaces;
using PackageAPI.Models;

namespace PackageAPI.Services
{
    public class packageRepo : IRepo<packages, int>
    {
        private readonly Context _context;
        public packageRepo(Context context)
        {
            _context = context;
        }

        public async Task<packages?> Add(packages item)
        {
            var pack = _context.Tourpackages.SingleOrDefault(p => p.packageId == item.packageId);
            if (pack == null)
            {
                try
                {
                    _context.Tourpackages.Add(item);
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

        public async Task<packages?> Delete(int id)
        {
            try
            {
                var pack = await Get(id);
                if (pack != null)
                {
                    _context.Tourpackages.Remove(pack);
                    await _context.SaveChangesAsync();
                    return pack;
                }
                return null;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<packages?> Get(int id)
        {
            try
            {
                var pack = await _context.Tourpackages.SingleOrDefaultAsync(p => p.packageId == id);
                if (pack == null)
                {
                    return null;
                }
                return pack;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<packages>?> GetAll()
        {
            try
            {
                var pack = await _context.Tourpackages.ToListAsync();
                if (pack != null)
                {
                    return pack;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<packages?> Update(packages item)
        {
            var pack = _context.Tourpackages.SingleOrDefault(p=>p.packageId == item.packageId);
            if (pack != null)
            {
                try
                {
                    pack.destination = item.destination;
                    pack.AgencyId=item.AgencyId;
                    pack.No_Days=item.No_Days;
                    pack.DepartureCity=item.DepartureCity;
                    pack.FromDate = item.FromDate;
                    pack.ToDate = item.ToDate;
                    pack.No_Nights=item.No_Nights;
                    pack.TourType=item.TourType;
                    pack.description=item.description;
                    pack.AccommodationIncluded=item.AccommodationIncluded;
                    pack.FoodIncluded=item.FoodIncluded;
                    pack.available = item.available;
                    await _context.SaveChangesAsync();
                    return pack;
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
