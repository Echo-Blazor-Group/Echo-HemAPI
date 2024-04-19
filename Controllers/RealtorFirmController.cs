using Echo_HemAPI.Data.Models;
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
        IRealtorFirmRepository _realtorFirmRepository;

        public RealtorFirmController(IRealtorFirmRepository realtorFirmRepository)
        {
            _realtorFirmRepository = realtorFirmRepository;
        }

        [HttpPost]
        public async Task<ActionResult<RealtorFirm>> AddAsync(RealtorFirm realtorFirm)
        {
            if (realtorFirm == null)
            {
                return BadRequest();
            }
            await _realtorFirmRepository.AddAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();
            // TODO: (Samed) Välj vilken return vi ska köra med, om jag kan få CreatedAtAction att funka:
            // Return success status code with a reference to the newly created object's URL
            //return CreatedAtAction(nameof(AddAsync), new { id = realtorFirm.RealtorFirmId }, realtorFirm);
            return Ok(realtorFirm);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealtorFirm>>> GetAllAsync()
        {
            IEnumerable<RealtorFirm> realtorFirmList = await _realtorFirmRepository.GetAllAsync();
            
            if (realtorFirmList == null)
            {
                return NotFound("No Realtor firms registrated yet.");
            }
            return Ok(realtorFirmList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealtorFirm>> GetByIdAsync(int id)
        {
            RealtorFirm realtorFirm = await _realtorFirmRepository.GetByIdAsync(id);
            
            if (realtorFirm == null)
            {
                return NotFound();
            }            
            return Ok(realtorFirm);
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
            // Response.Headers.Add("X-Removed-RealtorFirm-Successfully-Id", realtorFirm.RealtorFirmId.ToString());
            // Return a lightweight success response
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, RealtorFirm realtorFirm)
        {
            // If parameters don't match
            if  (id != realtorFirm.RealtorFirmId)
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
            Response.Headers.Add("X-Updated-RealtorFirm-Successfully-Id", realtorFirm.RealtorFirmId.ToString());
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
