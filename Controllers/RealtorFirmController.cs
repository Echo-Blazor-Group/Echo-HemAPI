using AutoMapper;
using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Echo_HemAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Controllers
{
    /// <summary>
    /// Author: Samed Salman
    /// Note to self: Se Microsofts dokumentation för detaljer: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio#routing-and-url-paths
    /// </summary>

    [Route("api/[controller]/")]
    [ApiController]
    public class RealtorFirmController : ControllerBase
    {
        private readonly IRealtorFirmRepository _realtorFirmRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Realtor> _userManager;
        private readonly IEstateRepository _estateRepository;
        private readonly ApplicationDbContext _dbContext;

        public RealtorFirmController(IRealtorFirmRepository realtorFirmRepository, IMapper mapper, UserManager<Realtor> userManager, IEstateRepository estateRepository, ApplicationDbContext dbContext)
        {
            _realtorFirmRepository = realtorFirmRepository;
            _mapper = mapper;
            _userManager = userManager;
            _estateRepository = estateRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Authorize(Roles = SD.SuperAdminOrRealtor)]
        public async Task<ActionResult<RealtorFirm>> AddAsync(RealtorFirmPostDTO realtorFirmPostDTO)
        {
            if (realtorFirmPostDTO == null)
            {
                return BadRequest();
            }
            // Map DTO to entity
            RealtorFirm realtorFirm = await _realtorFirmRepository.AddAsync(_mapper.Map<RealtorFirm>(realtorFirmPostDTO));
            // Save entity to db
            await _realtorFirmRepository.SaveChangesAsync();
            // Return success status code 201 with a reference to the newly created object's URL
            return CreatedAtAction(nameof(GetByIdAsync), new { id = realtorFirm.Id }, realtorFirm);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealtorFirmWithIdDTO>>> GetAllAsync()
        {
            // Get list of entities
            IEnumerable<RealtorFirm> realtorFirmList = await _realtorFirmRepository.GetAllAsync();

            // Check list of entities
            if (realtorFirmList == null)
            {
                return NotFound("No Realtor firms registrated yet.");
            }
            // Map list of entities to list of DTO:s
            return Ok(_mapper.Map<List<RealtorFirmWithIdDTO>>(realtorFirmList));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealtorFirmWithIdDTO>> GetByIdAsync(int id)
        {
            // Get entity
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);

            // Check entity
            if (realtorFirm == null)
            {
                return NotFound();
            }
            // Map entity and return only DTO
            return Ok(_mapper.Map<RealtorFirmWithIdDTO>(realtorFirm));
        }



        //Author: Seb
        [HttpGet("IsFirmEmpty/{id}")]
        public async Task<ActionResult<bool>> IsFirmEmpty(int id)
        {
            bool isFirmEmpty = true;
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);
            var employees = await _userManager.Users.Where(r => r.RealtorFirm == realtorFirm).ToListAsync();
            if (employees.Any())
            {
                isFirmEmpty = false;
            }

            return Ok(isFirmEmpty);
        }





        [HttpDelete("{id}")]
        [Authorize(Roles = SD.SuperAdmin)]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);


            if (realtorFirm == null)
            {
                return NotFound();
            }

            await _realtorFirmRepository.RemoveAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();

            // Add a custom header with the updated item's id to the Http response
            Response.Headers.Append("Removed-Realtor-Firm-Id", realtorFirm.Id.ToString());
            // Return a lightweight success response
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = SD.SuperAdmin)]
        public async Task<IActionResult> UpdateAsync(int id, RealtorFirm realtorFirm)
        {
            // If parameters don't match
            if (id != realtorFirm.Id)
            {
                return BadRequest("Id does not match");
            }

            await _realtorFirmRepository.UpdateAsync(realtorFirm);

            try
            {
                await _realtorFirmRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_realtorFirmRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // Add a custom header with the updated item's id to the Http response
            Response.Headers.Append("Updated-Realtor-Firm-Id", realtorFirm.Id.ToString());
            // Return a lightweight success response
            return NoContent();
        }
    }
}
