using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        IEstateRepository _estateRepository;

        public EstateController(IEstateRepository estateRepository)
        {
            _estateRepository = estateRepository;
        }

        [HttpPost]
        public async Task<Estate> AddAsync(Estate estate)
        {
            await _estateRepository.AddAsync(estate);
            await _estateRepository.SaveChangesAsync();
            return estate;
        }

        [HttpGet]
        public async Task<IEnumerable<Estate>?> GetAllAsync()
        {
            return await _estateRepository.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Estate> GetByIdAsync(int id)
        {
            return await _estateRepository.GetByIdAsync(id);
        }


        [HttpDelete]
        public async Task<Estate> RemoveAsync(Estate estate)
        {
            await _estateRepository.RemoveAsync(estate);
            await _estateRepository.SaveChangesAsync();
            return estate;
        }

        [HttpPut]
        public async Task<Estate> UpdateAsync(Estate estate)
        {
            await _estateRepository.UpdateAsync(estate);
            await _estateRepository.SaveChangesAsync();
            return estate;
        }
    }
}
