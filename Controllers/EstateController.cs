using AspNetCore;
using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Models.DTOs.RealtorDTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly IMapper mapper;

        public EstateController(IEstateRepository estateRepository, IMapper mapper)
        {
            _estateRepository = estateRepository;
            this.mapper = mapper;
        }

        public IMapper Mapper => mapper;

        [HttpPost]
        public async Task<IActionResult> AddAsync(InsertEstateDto insertEstateDto)
        {
              var estate = mapper.Map<Estate>(insertEstateDto);
            var estate = Mapper.Map<Estate>(insertEstateDto);
            var validationContext = new ValidationContext(estate);
            var validationResult = new List<ValidationResult>();

            if (!Validator.TryValidateObject(estate, validationContext, validationResult, true))
            {
                return BadRequest(new { Message = "Custom Validation Error", Errors = validationResult.Select(r => r.ErrorMessage) });
            }
            estate = await _estateRepository.UpdateAsync(estate);
            var estateDto = Mapper.Map<EstateDto>(estate);
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

        [HttpGet("{Id}")]
        public async Task<ActionResult<EstateDto>> GetByIdAsync(int id)
        {
   
            var estate = await _estateRepository.GetByIdAsync(id);
            //var user = await _userManager.Users.Include(u => u.RealtorFirm)
            //                                   .Where(u => u.Id == id)
            //                                   .FirstOrDefaultAsync();
            if (estate is not null)
            {
                var EstateToDto = Mapper.Map<EstateDto>(estate);
                return Ok(EstateToDto);

            }
            //if (user is not null)
            //{
            //    var userToDto = _mapper.Map<RealtorGetDTO>(user);
            //    return Ok(userToDto);
            //}
            else
            {
                return NotFound("Invalid id.");
            }
            //if (await _estateRepository.GetByIdAsync(id) == null)
            //{
            //    return null;
            //}

            //var estateObject = await _estateRepository.GetByIdAsync(id);
            //var estateDto = _mapper.Map<Estate>(estateObject);
            //return Ok(estateDto);

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

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateEstateDto updateEstateDto)
        {

            try
            {
                if (updateEstateDto == null)
                    return BadRequest(ModelState);

            var estateObject = mapper.Map<Estate>(updateEstateDto);
            await _estateRepository.UpdateAsync(estateObject);

            try
            { 
                var estateObject = Mapper.Map<Estate>(updateEstateDto);
                await _estateRepository.UpdateAsync(estateObject);
                await _estateRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_estateRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();

        }
    }
}
