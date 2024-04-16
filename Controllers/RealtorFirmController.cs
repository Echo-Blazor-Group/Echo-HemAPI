using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Echo_HemAPI.Controllers
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class RealtorFirmController : ControllerBase
    {
        IRealtorFirmRepository _realtorFirmRepository;

        public RealtorFirmController(IRealtorFirmRepository realtorFirmRepository)
        {
            _realtorFirmRepository = realtorFirmRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RealtorFirm>> GetListOfRealtorFirmsAsync()
        {
            return await _realtorFirmRepository.GetAllRealtorFirmsAsync();
        }

        [HttpPost]
        public async Task<RealtorFirm> AddRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            return await _realtorFirmRepository.AddRealtorFirmAsync(realtorFirm);
        }
    }
}
