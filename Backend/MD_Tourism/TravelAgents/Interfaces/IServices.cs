using TravelAgents.Models;
using TravelAgents.Models.DTO;

namespace TravelAgents.Interfaces
{
    public interface IServices
    {
        public Task<UserDTO?> TravelAgentsRegister(TravelAgentRegisterDTO travelAgentRegDTO);
        public Task<UserDTO?> TravelAgentsLogin(UserDTO userDTO);
        public Task<TravelAgentFeedback?> FeedbackTravelAgent(TravelAgentFeedback feedback);
    }
}
