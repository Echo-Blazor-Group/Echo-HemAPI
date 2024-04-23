using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> AddAsync(InsertEstateDto insertEstateDto)
        {
              var estate = mapper.Map<Estate>(insertEstateDto);
            var validationContext = new ValidationContext(estate);
            var validationResult = new List<ValidationResult>();

            if (!Validator.TryValidateObject(estate, validationContext, validationResult, true))
            {
                return BadRequest(new {Message = "Custom Validation Error", Errors = validationResult.Select(r=>r.ErrorMessage)});
            }
            estate = await _estateRepository.UpdateAsync(estate);
            var estateDto = mapper.Map<EstateDto>(estate);
            await _estateRepository.SaveChangesAsync();
            return Created("/api/estate" + estate.Id, new { Message = "estate created!", Data = estateDto });
               

               //Estate = await _estateRepository.AddAsync(estate);
   
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
