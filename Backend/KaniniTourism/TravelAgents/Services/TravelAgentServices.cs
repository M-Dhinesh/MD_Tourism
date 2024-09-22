using System.Security.Cryptography;
using System.Text;
using TravelAgents.Interfaces;
using TravelAgents.Models;
using TravelAgents.Models.DTO;

namespace TravelAgents.Services
{
    public class TravelAgentServices : IServices
    {
        private readonly IRepo<TravelAgent, int> _travelAgentRepo;
        private readonly IRepo<TravelAgentUser, int> _userRepo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IRepo<TravelAgentFeedback, int> _feedbackRepo;

        public TravelAgentServices(IRepo<TravelAgent, int> travelerRepo,
                           IRepo<TravelAgentUser, int> userRepo, ITokenGenerate tokenGenerate,
                           IRepo<TravelAgentFeedback, int> FeedbackRepo)
        {
            _travelAgentRepo = travelerRepo;
            _userRepo = userRepo;
            _tokenGenerate = tokenGenerate;
            _feedbackRepo = FeedbackRepo;
        }

        public async Task<TravelAgentFeedback?> FeedbackTravelAgent(TravelAgentFeedback feedback)
        {
            var feedbacks = await _feedbackRepo.Add(feedback);
            if (feedbacks != null)
            {
                return feedbacks;
            }
            return null;
        }

        public async Task<UserDTO?> TravelAgentsLogin(UserDTO user)
        {
            var userData = await _userRepo.Get(user.EmailId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.Role = userData.Role;
                user.Token = _tokenGenerate.GenerateToken(user);
                return user;
            }
            return null;
        }

        public async Task<UserDTO?> TravelAgentsRegister(TravelAgentRegisterDTO travelAgentRegDTO)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            travelAgentRegDTO.Users = new TravelAgentUser();
            travelAgentRegDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(travelAgentRegDTO.PasswordClear));
            travelAgentRegDTO.Users.PasswordKey = hmac.Key;
            travelAgentRegDTO.Users.EmailId = travelAgentRegDTO.Email;
            travelAgentRegDTO.Users.Role = "TravelAgent";
            var userResult = await _userRepo.Add(travelAgentRegDTO.Users);

            var travellerResult = await _travelAgentRepo.Add(travelAgentRegDTO);
            if (userResult != null && travellerResult != null)
            {
                user = new UserDTO();
                user.UserId = userResult.UserId;
                user.Role = "TravelAgent";
                user.EmailId = travellerResult.Email;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }
    }
}
