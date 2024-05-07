using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureRepository _pictureRepository;

        public PicturesController(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var category = await _pictureRepository.GetAllAsync();
            return Ok(category);
        }
    }
}
