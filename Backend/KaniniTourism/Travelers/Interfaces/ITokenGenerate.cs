using Travelers.Models.DTO;

namespace Travelers.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
