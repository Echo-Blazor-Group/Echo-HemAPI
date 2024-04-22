using AutoMapper;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Controllers
{
    /// <summary>
    /// Author: Samed Salman
    /// Se Microsofts dokumentation för detaljer: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio#routing-and-url-paths
    /// </summary>

    [Route("api/[controller]/")]
    [ApiController]
    public class RealtorFirmController : ControllerBase
    {
        private readonly IRealtorFirmRepository _realtorFirmRepository;
        private readonly IMapper _mapper;

        public RealtorFirmController(IRealtorFirmRepository realtorFirmRepository, IMapper mapper)
        {
            _realtorFirmRepository = realtorFirmRepository;
            _mapper = mapper;
        }

        [HttpPost]
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
            // TODO: (Samed) Välj vilken return vi ska köra med, om jag kan få CreatedAtAction att funka:
            // Return success status code with a reference to the newly created object's URL
            return CreatedAtAction(nameof(this.GetByIdAsync), new { id = realtorFirm.RealtorFirmId }, realtorFirm);
            // return Ok(realtorFirmPostDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealtorFirmGetDTO>>> GetAllAsync()
        {
            // Get list of entities
            IEnumerable<RealtorFirm> realtorFirmList = await _realtorFirmRepository.GetAllAsync();
            
            // Check list of entities
            if (realtorFirmList == null)
            {
                return NotFound("No Realtor firms registrated yet.");
            }

            // Map list of entities to list of DTO:s
            return Ok(_mapper.Map<List<RealtorFirmGetDTO>>(realtorFirmList));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealtorFirmGetDTO>> GetByIdAsync(int id)
        {
            // Get entity
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);
            
            // Check entity
            if (realtorFirm == null)
            {
                return NotFound();
            }
            // Map entity to return only DTO
            return Ok(_mapper.Map<RealtorFirmGetDTO>(realtorFirm));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);

            if (realtorFirm == null)
            {
                return NotFound();
            }

            await _realtorFirmRepository.RemoveAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();

            // TODO: (Samed) Funkar det här för våra syften eller är det bättre att returnera hela objektet i svaret?
            // Add a custom header with the updated item's id to the Http response
            Response.Headers.Add("X-Removed-RealtorFirm-Successfully-Id", realtorFirm.RealtorFirmId.ToString());
            // Return a lightweight success response
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, RealtorFirm realtorFirm)
        {
            // If parameters don't match
            if  (id != realtorFirm.Id)
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
                if(_realtorFirmRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // TODO: (Samed) Funkar det här för våra syften eller är det bättre att returnera hela objektet i svaret?
            // Add a custom header with the updated item's id to the Http response
            Response.Headers.Add("X-Updated-RealtorFirm-Successfully-Id", realtorFirm.Id.ToString());
            // Return a lightweight success response
            return NoContent();
        }

        // TODO: (Samed) Ev Ta bort?
        //[HttpGet("find/{predicate}")]
        //public async Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate)
        //{
        //    return await _realtorFirmRepository.FindAsync(predicate);
        //}
    }
}
