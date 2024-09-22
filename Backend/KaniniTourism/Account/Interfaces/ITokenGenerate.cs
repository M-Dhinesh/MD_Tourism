using AccountAPI.Models.DTO;

namespace AccountAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
