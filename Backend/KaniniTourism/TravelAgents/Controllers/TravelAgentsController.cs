using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgents.Interfaces;
using TravelAgents.Models;
using TravelAgents.Models.DTO;

namespace TravelAgents.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    [EnableCors("MyCors")]
    public class TravelAgentsController : ControllerBase
    {
        private readonly IServices _iservice;

        public TravelAgentsController(IServices iservice)
        {
            _iservice = iservice;
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterTravelAgent(TravelAgentRegisterDTO travelAgentDTO)
        {
            try
            {
                var traveller = await _iservice.TravelAgentsRegister(travelAgentDTO);
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
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> LoginTravelAgent(UserDTO travelersDTO)
        {
            try
            {
                var traveller = await _iservice.TravelAgentsLogin(travelersDTO);
                if (traveller != null)
                    return Created("Logged in! :)", traveller);
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(TravelAgentFeedback), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<TravelAgentFeedback?>> FeedbackTravelAgent(TravelAgentFeedback feedback)
        {
            try
            {
                var traveller = await _iservice.FeedbackTravelAgent(feedback);
                if (traveller != null)
                    return Created("Logged in! :)", traveller);
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }
    }
}
