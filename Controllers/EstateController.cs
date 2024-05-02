
using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using NuGet.Protocol;
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
        private readonly UserManager<Realtor> _userManager;
        private readonly IMapper mapper;

        public EstateController(IEstateRepository estateRepository, 
            IMapper mapper, 
            ICategoryRepository categoryRepository, 
            ICountyRepository countyRepository, 
            UserManager<Realtor> userManager)
        {
            _estateRepository = estateRepository;
            this.mapper = mapper;
            _categoryRepository = categoryRepository;
            _countyRepository = countyRepository;
            _userManager = userManager;
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
        public async Task<ActionResult<EstateDto>> GetByIdAsync(int id)
        {

            var estate = await _estateRepository.GetByIdAsync(id);

            if (estate is not null)
            {
                var EstateToDto = mapper.Map<EstateDto>(estate);
                return Ok(EstateToDto);
            }
            else
            {
                return NotFound("Invalid id.");
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

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateEstateDto updateEstateDto)
        {
                var dbEstate = await _estateRepository.GetByIdAsync(id);
                if (updateEstateDto == null)
                    return BadRequest(ModelState);
                if (id != updateEstateDto.Id)
                    return BadRequest(ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                //var estateMap = mapper.Map<Estate>(updateEstateDto);

                dbEstate.Address = updateEstateDto.Address;
                dbEstate.StartingPrice = updateEstateDto.StartingPrice;
                dbEstate.LivingAreaKvm = updateEstateDto.LivingAreaKvm;
                dbEstate.NumberOfRooms = updateEstateDto.NumberOfRooms;
                dbEstate.BiAreaKvm = updateEstateDto.BiAreaKvm;
                dbEstate.EstateAreaKvm = updateEstateDto.EstateAreaKvm;
                dbEstate.MonthlyFee = updateEstateDto.MonthlyFee;
                dbEstate.RunningCosts = updateEstateDto.RunningCosts;
                dbEstate.ConstructionDate = updateEstateDto.ConstructionDate;
                dbEstate.EstateDescription = updateEstateDto.EstateDescription;
                dbEstate.PublishDate = updateEstateDto.PublishDate;
                var county = await _countyRepository.GetByIdAsync(updateEstateDto.CountyId);
                var category = await _categoryRepository.GetByIdAsync(updateEstateDto.CategoryId);
                var realtor = await _userManager.FindByIdAsync(updateEstateDto.RealtorId);
                dbEstate.County = county;
                dbEstate.Category = category;
                dbEstate.Realtor = realtor;

                await _estateRepository.UpdateAsync(dbEstate);
                await _estateRepository.SaveChangesAsync();
                return Ok(dbEstate);


        }
    }
}
