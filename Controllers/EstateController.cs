using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs.EstateDtos;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;



//Author Gustaf

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        //object brings along other objects
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
                return BadRequest(new { Message = "Custom Validation Error", Errors = validationResult.Select(r => r.ErrorMessage) });
            }
            var county = await _countyRepository.GetByIdAsync(insertEstateDto.CountyId);
            var category = await _categoryRepository.GetByIdAsync(insertEstateDto.CategoryId);
            var realtor = await _userManager.FindByIdAsync(insertEstateDto.RealtorId);
            estate.County = county;
            estate.Category = category;
            estate.Realtor = realtor;
            estate = await _estateRepository.UpdateAsync(estate);
            
            await _estateRepository.SaveChangesAsync();
            return Created("/api/estate" + estate.Id, new { Message = "estate created!", Data = estate });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var estates = await _estateRepository.GetAllAsync();
            var estateDto = mapper.Map<List<Estate>>(estates);

            return Ok(estateDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDto>> GetByIdAsync(int id)
        {
            var estate = await _estateRepository.GetByIdAsync(id);

            if (estate is not null)
            {
                var EstateToDto = mapper.Map<Estate>(estate);
                
                return Ok(EstateToDto);
            }
            else
            {
                return NotFound("Invalid id.");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody]DeleteEstateDto deleteEstateDto)
        {
            var dbEstate = await _estateRepository.GetByIdAsync(id);
            if (deleteEstateDto == null)
                return BadRequest(ModelState);
            if (id != deleteEstateDto.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(dbEstate.OnTheMarket == true)
            {
                dbEstate.OnTheMarket = deleteEstateDto.OnTheMarket = false;
            }
            else
            {
                dbEstate.OnTheMarket = deleteEstateDto.OnTheMarket = true;
            }
            
            await _estateRepository.UpdateAsync(dbEstate);
            await _estateRepository.SaveChangesAsync();
            return Ok(dbEstate);
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
            //We decided to not use the mapper on the update function as the problems would not solve themselves, maybe it was related to 
            //the pictures objects being slightly wrongly made, don't know but in the interest of finishing the project on time.
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
            dbEstate.OnTheMarket = updateEstateDto.OnTheMarket;
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
