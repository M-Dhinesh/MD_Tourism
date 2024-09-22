using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageAPI.Interfaces;
using PackageAPI.Models;
using PackageAPI.Models.DTO;

namespace PackageAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("myCORS")]
    public class PackageController : ControllerBase
    {
        private readonly IRepo<packages, int> _packageRepo;
        private readonly IService _service;
        public PackageController(IRepo<packages,int> packageRepo, IService service)
        {
            _packageRepo = packageRepo;
            _service = service;

        }

        [HttpPost]
        [ProducesResponseType(typeof(packages), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<packages?>> AddPackage(packages pack)
        {
            try
            {
                var tourpackage = await _packageRepo.Add(pack);
                if (tourpackage != null)
                {
                    return Created("Added!", tourpackage);
                }
                return BadRequest("Unable to add");
            }
            catch (Exception)
            {
                return BadRequest("Backend error :(");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<packages>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<packages>>> GetAllPakages()
        {
            try
            {
                var tourPackages = await _packageRepo.GetAll();
                if (tourPackages != null)
                {
                    return Ok(tourPackages);
                }
                return BadRequest("No packages available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(packages), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<packages>> GetPackage(int id)
        {
            try
            {
                var tourpackage = await _packageRepo.Get(id);
                if (tourpackage != null)
                {
                    return Ok(tourpackage);
                }
                return BadRequest("No package found :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(packages), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<packages>> DeletePackage(int id)
        {
            try
            {
                var tourpackage = await _packageRepo.Delete(id);
                if (tourpackage != null)
                {
                    return Ok(tourpackage);
                }
                return BadRequest("Not deleted");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(packages), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<packages>> UpdatePackage(packages item)
        {
            try
            {
                var tourpackage = await _packageRepo.Update(item);
                if (tourpackage != null)
                {
                    return Ok(tourpackage);
                }
                return BadRequest("Not updated");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<packages>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<packages>>> GetPackageByDestination(string dest)
        {
            try
            {
                var tourPackages = await _service.GetPackageByDestination(dest);
                if (tourPackages != null)
                {
                    return Ok(tourPackages);
                }
                return BadRequest("No tours available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<packages>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<packages>>> GetPackageByAgentID(int id)
        {
            try
            {
                var tourPackages = await _service.GetPackageByAgentID(id);
                if (tourPackages != null)
                {
                    return Ok(tourPackages);
                }
                return BadRequest("No tours available :(");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(packages), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<packages>> UpdateAvailableCount(UpdateAvailableDTO availableDTO)
        {
            try
            {
                var tourpackage = await _service.UpdateAvailable(availableDTO);
                if (tourpackage != null)
                {
                    return Ok(tourpackage);
                }
                return BadRequest("Not updated");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }
    }
}
