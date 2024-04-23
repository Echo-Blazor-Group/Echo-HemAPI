using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

//Author Gustaf

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IMapper mapper;

        public EstateController(IEstateRepository estateRepository, IMapper mapper)
        {
            _estateRepository = estateRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<Estate> AddAsync(Estate estate)
        {
            if (estate == null)
            {
                return null;
            }
            else
            {
                await _estateRepository.AddAsync(estate);
                await _estateRepository.SaveChangesAsync();
                return estate;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var estates = await _estateRepository.GetAllAsync();
            var estateDto = mapper.Map<List<EstateDto>>(estates); 
            return Ok(estateDto);
            
        }

        [HttpGet("{id}")]
        public async Task<Estate> GetByIdAsync(int id)
        {
            if (await _estateRepository.GetByIdAsync(id) == null)
            {
                return null;
            }
            else
            {
                return await _estateRepository.GetByIdAsync(id);
            }
        }

        [HttpDelete]
        public async Task<Estate> RemoveAsync(Estate estate)
        {
            if (estate == null)
            {
                return null;
            }
            else
            {
                await _estateRepository.RemoveAsync(estate);
                await _estateRepository.SaveChangesAsync();
                return estate;
            }

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
