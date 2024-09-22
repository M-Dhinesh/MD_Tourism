using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travelers.Interfaces;
using Travelers.Models;
using Travelers.Models.DTO;

namespace Travelers.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    [EnableCors("MyCors")]
    public class TravelersController : ControllerBase
    {
        private readonly IService _iservice;

        public TravelersController(IService iservice)
        {
            _iservice = iservice;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response

        public async Task<ActionResult<UserDTO?>> RegisterTraveller(TravelersRegisterDTO travelersDTO)
        {
            try
            {
                var traveller = await _iservice.TravelersRegister(travelersDTO);
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
        public async Task<ActionResult<UserDTO?>> LoginTraveller(UserDTO travelersDTO)
        {
            try
            {
                var traveller = await _iservice.TravelersLogin(travelersDTO);
                if (traveller != null)
                    return Created("Logged in! :)", traveller);
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error!");
            }
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(Feedback), StatusCodes.Status201Created)]//Success Response
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        //public async Task<ActionResult<Feedback?>> FeedbackTraveller(Feedback feedback)
        //{
        //    try
        //    {
        //        var traveller = await _iservice.FeedbackTraveller(feedback);
        //        if (traveller != null)
        //            return Created("Logged in! :)", traveller);
        //        return BadRequest("Unable to login");
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Network error!");
        //    }
        //}
    }
}
