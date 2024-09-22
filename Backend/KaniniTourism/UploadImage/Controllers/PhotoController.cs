using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Interfaces;
using UploadImage.Services;

namespace UploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhotoController : ControllerBase
    {
        private readonly IService _pic;
        public PhotoController(IService pic)
        {
            _pic = pic;

        }
        [HttpPost]
        public void UploadImage()
        {
            _pic.GetPic();
        }
    }
}
