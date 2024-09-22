using TravelAgents.Models.DTO;

namespace TravelAgents.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
