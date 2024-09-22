using AccountAPI.Models;
using AccountAPI.Models.DTO;

namespace AccountAPI.Interfaces
{
    public interface IAdminService
    {
        public Task<Agent?> UpdateStatus(StatusDTO status);
    }
}
