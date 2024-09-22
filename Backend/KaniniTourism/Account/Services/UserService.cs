using AccountAPI.Interfaces;
using AccountAPI.Models;
using AccountAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace AccountAPI.Services
{
    public class UserService:IService
    {
        private readonly IRepo<User, string> _userRepo;
        private readonly IRepo<Agent, string> _agentRepo;
        private readonly IRepo<Traveller, string> _travellerRepo;
        private readonly ITokenGenerate _tokenGenerate;

        public UserService(IRepo<User,string> userRepo,IRepo<Agent,string> agentRepo,
                           IRepo<Traveller,string> travellerRepo,ITokenGenerate tokenGenerate)
        {
            _agentRepo = agentRepo;
            _userRepo = userRepo;   
            _travellerRepo = travellerRepo;
            _tokenGenerate = tokenGenerate;
        }

        public async Task<UserDTO?> AgentRegister(AgentRegDTO agentRegDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            agentRegDTO.Users = new User();
            agentRegDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(agentRegDTO.PasswordClear));
            agentRegDTO.Users.PasswordKey = hmac.Key;
            agentRegDTO.Users.Email = agentRegDTO.Email;
            agentRegDTO.Users.Role = "Agent";
            agentRegDTO.IsApproved = "Not approved";
            var userResult = await _userRepo.Add(agentRegDTO.Users);
            var agentResult = await _agentRepo.Add(agentRegDTO);
            if(userResult != null && agentResult != null)
            {
                user = new UserDTO();
                user.UserId = userResult.UserId;
                user.Email=userResult.Email;
                user.Role = userResult.Role;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO?> Login(UserDTO userDTO)
        {
            var userData = await _userRepo.Get(userDTO.Email);
            if(userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for(int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                userDTO = new UserDTO();
                userDTO.UserId = userData.UserId;
                userDTO.Email = userData.Email;
                userDTO.Role = userData.Role;
                userDTO.Token = _tokenGenerate.GenerateToken(userDTO);
                return userDTO;
            }
            return null;
        }

        public async Task<UserDTO?> TravellerRegister(TravellerRegDTO travellerDTO)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            travellerDTO.Users = new User();
            travellerDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(travellerDTO.PasswordClear));
            travellerDTO.Users.PasswordKey = hmac.Key;
            travellerDTO.Users.Role = "traveller";
            travellerDTO.Users.Email = travellerDTO.Email;
            var userResult = await _userRepo.Add(travellerDTO.Users);
            var travellerResult = await _travellerRepo.Add(travellerDTO);
            if(userResult!=null && travellerResult != null)
            {
                user = new UserDTO();
                user.UserId = userResult.UserId;
                user.Role = userResult.Role;
                user.Email = travellerResult.Email;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }
    }
}
