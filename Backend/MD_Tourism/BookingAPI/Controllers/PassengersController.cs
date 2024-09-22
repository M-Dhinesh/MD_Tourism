using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class passengersController : ControllerBase
    {
        private readonly IRepo<Passengers, int> _travellerRepo;
        private readonly IManageBooking _manageService;

        public passengersController(IRepo<Passengers, int> travellerRepo, IManageBooking manageService)
        {
            _travellerRepo = travellerRepo;
            _manageService = manageService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Passengers), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<Passengers?>> Addpassenger(Passengers item)
        {
            try
            {
                var passenger = await _travellerRepo.Add(item);
                if (passenger != null)
                {
                    return Created("Added!", passenger);
                }
                return BadRequest("Unable to add");
            }
            catch (Exception)
            {
                return BadRequest("Backend error :(");
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Passengers>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Passengers>>> GetAllPassengers()
        {
            try
            {
                var passenger = await _travellerRepo.GetAll();
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No extra travellers available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Passengers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Passengers>> GetPassenger(int id)
        {
            try
            {
                var passenger = await _travellerRepo.Get(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No passenger found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Passengers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Passengers>> DeletePassenger(int id)
        {
            try
            {
                var passenger = await _travellerRepo.Delete(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("Not deleted");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Passengers), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Passengers>> UpdatePassengers(Passengers item)
        {
            try
            {
                var passenger = await _travellerRepo.Update(item);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("Not updated");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Passengers>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Passengers>>> GetGuestsbyTraveller(string id)
        {
            try
            {
                var passenger = await _manageService.GetGuestsByTravellerEmail(id);
                if (passenger != null)
                {
                    return Ok(passenger);
                }
                return BadRequest("No passengers available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }
    }
}
