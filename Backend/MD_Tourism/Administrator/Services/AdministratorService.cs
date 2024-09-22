using Administrator.Interfaces;
using Administrator.Models.DTO;
using TravelAgents.Models;
namespace Administrator.Services
{
    public class AdministratorService:IService
    {
        private readonly IRepo<TravelAgent, string> _agentRepo;
        public AdministratorService(IRepo<TravelAgent, string> agentRepo)
        {
            _agentRepo = agentRepo;
        }
        public async Task<TravelAgent?> UpdateStatus(StatusDTO status)
        {
            try
            {
                var agent = await _agentRepo.Get(status.AgentEmail);
                if (agent == null) { return null; }
                agent.IsApproved = status.Status;
                var updatedAgent = await _agentRepo.Update(agent);
                if (updatedAgent == null) { return null; }
                return updatedAgent;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
