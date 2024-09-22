using Travelers.Models;
using Travelers.Models.DTO;

namespace Travelers.Interfaces
{
    public interface IService
    {
        public Task<UserDTO?> TravelersRegister(TravelersRegisterDTO travellerRegDTO);
        public Task<UserDTO?> TravelersLogin(UserDTO userDTO);

        //public Task<Feedback?> FeedbackTraveller(Feedback feedback);
    }
}
