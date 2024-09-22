using AccountAPI.Models;

namespace AccountAPI.Models.DTO
{
    public class TravellerRegDTO:Traveller
    {
        public string? PasswordClear { get; set; }
    }
}
