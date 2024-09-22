using PackageAPI.Models;
using PackageAPI.Models.DTO;

namespace PackageAPI.Interfaces
{
    public interface IService
    {
        public Task<ICollection<packages>?> GetPackageByDestination(string destination);
        public Task<packages?> UpdateAvailable(UpdateAvailableDTO availableDTO);

        public Task<ICollection<packages>?> GetPackageByAgentID(int agentID);
    }
}
