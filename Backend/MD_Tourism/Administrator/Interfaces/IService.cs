using Administrator.Models.DTO;
using TravelAgents.Models;

namespace Administrator.Interfaces
{
    public interface IService
    {
        public Task<TravelAgent?> UpdateStatus(StatusDTO status);
    }
}
