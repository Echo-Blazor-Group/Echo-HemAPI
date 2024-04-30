using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ICountyRepository _CountyRepository;

        public CountyController(ICountyRepository countyRepository)
        {
            _CountyRepository = countyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var county = await _CountyRepository.GetAllAsync();
            return Ok(county);
        }
    }
}
