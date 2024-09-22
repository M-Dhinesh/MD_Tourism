using Administrator.Interfaces;
using Administrator.Models;
using Administrator.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgents.Models;

namespace Administrator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IService _adminService;
        public AdministratorController(IService adminService)
        {
            _adminService = adminService;
        }
        [HttpPut]
        [ProducesResponseType(typeof(TravelAgent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        public async Task<ActionResult<TravelAgent?>> UpdateAgentStatus(StatusDTO status)
        {
            try
            {
                var agent = await _adminService.UpdateStatus(status);
                if (agent != null)
                {
                    return Ok(agent);
                }
                return BadRequest("Not updated!");
            }
            catch (Exception)
            {
                return BadRequest("Backend error!");
            }
        }
    }
}
