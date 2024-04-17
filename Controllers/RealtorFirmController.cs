using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

        // TODO: Lägg till null-hantering, se dokumentationen: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio#routing-and-url-paths

        // TODO: Hur göra med Post/put/remove-metoder och SaveChanges? Är nedanstående korrekt?
        [HttpPost]
        public async Task<RealtorFirm> AddAsync(RealtorFirm realtorFirm)
        {
            await _realtorFirmRepository.AddAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();
            return realtorFirm;
        }

        [HttpGet]
        public async Task<IEnumerable<RealtorFirm>> GetAllAsync()
        {
            return await _realtorFirmRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<RealtorFirm> GetByIdAsync(int id)
        {
            return await _realtorFirmRepository.GetByIdAsync(id);
        }

        [HttpDelete]
        public async Task<RealtorFirm> RemoveAsync(RealtorFirm realtorFirm)
        {
            await _realtorFirmRepository.RemoveAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();
            return realtorFirm;
        }

        [HttpPut]
        public async Task<RealtorFirm> UpdateAsync(RealtorFirm realtorFirm)
        {
            await _realtorFirmRepository.UpdateAsync(realtorFirm);
            await _realtorFirmRepository.SaveChangesAsync();
            return realtorFirm;
        }

        // TODO: Osäker på den här metodens syntax och funktion
        [HttpGet("{predicate}")]
        public async Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate)
        {
            return await _realtorFirmRepository.FindAsync(predicate);
        }
    }
}
