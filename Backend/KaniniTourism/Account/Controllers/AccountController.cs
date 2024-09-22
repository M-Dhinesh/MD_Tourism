using AccountAPI.Interfaces;
using AccountAPI.Models;
using AccountAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

    namespace AccountAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("myCORS")]
    public class AccountController : ControllerBase
    {
        private readonly IService _userService;
        private readonly IRepo<User, string> _userRepo;
        private readonly IRepo<Traveller, string> _travellerRepo;
        private readonly IRepo<Agent, string> _agentRepo;
        private readonly IAdminService _adminService;

        public AccountController(IService userService, IRepo<User, string> userRepo,
                              IRepo<Traveller, string> travellerRepo, IRepo<Agent, string> agentRepo
                             ,IAdminService adminService)
        {
            _agentRepo = agentRepo;
            _userService = userService;
            _userRepo = userRepo;
            _travellerRepo = travellerRepo;
            _adminService = adminService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterAgent(AgentRegDTO agentDTO)
        {
            try
            {
                var agent = await _userService.AgentRegister(agentDTO);
                if (agent != null)
                    return Created("Registered! :)", agent);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterTraveller(TravellerRegDTO travellerDTO)
        {
            try
            {
                var traveller = await _userService.TravellerRegister(travellerDTO);
                if (traveller != null)
                    return Created("Registered! :)", traveller);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.Login(userDTO);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error...Please try later");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        public async Task<ActionResult<Agent?>> UpdateAgentStatus(StatusDTO status)
        {
            try
            {
                var agent = await _adminService.UpdateStatus(status);
                if(agent != null)
                {
                    return Ok(agent);
                }
                return BadRequest("Not updated!");
            }
            catch(Exception)
            {
                return BadRequest("Backend error!");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Agent>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Agent>>> GetAllAgents()
        {
            try
            {
                var agents = await _agentRepo.GetAll();
                if(agents != null)
                {
                    return Ok(agents);
                }
                return BadRequest("No Agents available :(");
            }
            catch(Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Agent>> GetAgent(string email)
        {
            try
            {
                var agent = await _agentRepo.Get(email);
                if(agent != null)
                {
                    return Ok(agent);
                }
                return BadRequest("No agent found :(");
            }
            catch(Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Traveller>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Agent>>> GetAllTravellers()
        {
            try
            {
                var agents = await _travellerRepo.GetAll();
                if (agents != null)
                {
                    return Ok(agents);
                }
                return BadRequest("No travellers available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(Agent), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Agent>> GetTraveller(string email)
        {
            try
            {
                var traveller = await _travellerRepo.Get(email);
                if (traveller != null)
                {
                    return Ok(traveller);
                }
                return BadRequest("No agent found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }
    }
}