using AccountAPI.Models.DTO;

namespace AccountAPI.Interfaces
{
    public interface IService
    {
        public Task<UserDTO?> AgentRegister(AgentRegDTO agentRegDTO);
        public Task<UserDTO?> TravellerRegister(TravellerRegDTO travellerDTO);
        public Task<UserDTO?> Login(UserDTO userDTO);
    }
}
