using PackageAPI.Interfaces;
using PackageAPI.Models;
using PackageAPI.Models.DTO;

namespace PackageAPI.Services
{
    public class packageService : IService
    {
        private readonly IRepo<packages, int> _packagesRepo;
        public packageService(IRepo<packages, int> packagesRepo)
        {
            _packagesRepo = packagesRepo;
        }

        public async Task<ICollection<packages>?> GetPackageByAgentID(int agentID)
        {
            try
            {
                var packagesByAgentID = await _packagesRepo.GetAll();
                if (packagesByAgentID == null)
                {
                    return null;
                }

                // Convert both the search term and stored destinations to lowercase for comparison

                // Use StringComparison.OrdinalIgnoreCase for case-insensitive comparison
                return packagesByAgentID
                    .Where(package => package.AgencyId == agentID)
                    .ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<packages>?> GetPackageByDestination(string destination)
        {
            try
            {
                var packagesByDestination = await _packagesRepo.GetAll();
                if (packagesByDestination == null)
                {
                    return null;
                }

                // Convert both the search term and stored destinations to lowercase for comparison
                var lowercaseDestination = destination.ToLower();

                // Use StringComparison.OrdinalIgnoreCase for case-insensitive comparison
                return packagesByDestination
                    .Where(package => package.destination?.ToLower().Trim() == lowercaseDestination)
                    .ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<packages?> UpdateAvailable(UpdateAvailableDTO availableDTO)
        {
            try
            { 
                var pack = await _packagesRepo.Get(availableDTO.packageId);
                if (pack == null) { return null; }
                pack.available = availableDTO.available;
                var updatedPack = await _packagesRepo.Update(pack);
                if (updatedPack == null) { return null; }
                return updatedPack;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
