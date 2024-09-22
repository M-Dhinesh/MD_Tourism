using Travelers.Interfaces;
using Travelers.Models;
using Travelers.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace Travelers.Services
{
    public class TravelersServices : IService
    {
        private readonly IRepo<Traveler, int> _travellerRepo;
        private readonly IRepo<TravelerUser, int> _userRepo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IRepo<TravelerFeedback,int> _feedbackRepo;

        public TravelersServices(IRepo<Traveler, int> travellerRepo,
                           IRepo<TravelerUser, int> userRepo, ITokenGenerate tokenGenerate, IRepo<TravelerFeedback, int> FeedbackRepo)
        {
            _travellerRepo = travellerRepo;
            _userRepo = userRepo;
            _tokenGenerate = tokenGenerate;
            _feedbackRepo = FeedbackRepo;
        }

        public async Task<TravelerFeedback?> FeedbackTraveller(TravelerFeedback feedback)
        {
            var feedbacks = await _feedbackRepo.Add(feedback);
            if (feedbacks != null)
            {
                return feedbacks;
            }
            return null;
        }

        public async Task<UserDTO?> TravelersLogin(UserDTO user)
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

        public async Task<UserDTO?> TravelersRegister(TravelersRegisterDTO travellerRegDTO)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            travellerRegDTO.Users = new TravelerUser();
            travellerRegDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(travellerRegDTO.PasswordClear));
            travellerRegDTO.Users.PasswordKey = hmac.Key;
            travellerRegDTO.Users.EmailId = travellerRegDTO.Email;
            travellerRegDTO.Users.Role = "Traveler";
            var userResult = await _userRepo.Add(travellerRegDTO.Users);

            var travellerResult = await _travellerRepo.Add(travellerRegDTO);
            if (userResult != null && travellerResult != null)
            {
                user = new UserDTO();
                user.UserId = userResult.UserId;
                user.Role = "Traveler";
                user.EmailId = travellerResult.Email;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }
    }
}

