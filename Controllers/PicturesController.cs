using AutoMapper;
using Echo_HemAPI.Data.Models.DTOs.EstateDtos;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Echo_HemAPI.Data.Repositories.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Echo_HemAPI.Data.Models.DTOs.PictureDtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper mapper;
        public PicturesController(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pictures = await _pictureRepository.GetAllAsync();
            return Ok(pictures);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PictureDto>> GetByIdAsync(int id)
        {
            var picture = await _pictureRepository.GetByIdAsync(id);

            if (picture is not null)
            {
                var pictureToDto = mapper.Map<Picture>(picture);

                return Ok(pictureToDto);
            }
            else
            {
                return NotFound("Invalid id.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(InsertPictureDto picture)
        {
            var pictureToAdd = mapper.Map<Picture>(picture);

            var validationContext = new ValidationContext(pictureToAdd);
            var validationResult = new List<ValidationResult>();

            if (!Validator.TryValidateObject(pictureToAdd, validationContext, validationResult, true))
            {
                return BadRequest(new { Message = "Custom Validation Error", Errors = validationResult.Select(r => r.ErrorMessage) });
            }

            pictureToAdd = await _pictureRepository.UpdateAsync(pictureToAdd);

            await _pictureRepository.SaveChangesAsync();
            return Created("/api/estate" + pictureToAdd.Id, new { Message = "estate created!", Data = pictureToAdd });
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdatePictureDto updatePictureDto)
        {
            var pictureToEdit = mapper.Map<Picture>(updatePictureDto);
            
            if (updatePictureDto == null)
                return BadRequest(ModelState);
            if (id != updatePictureDto.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pictureRepository.UpdateAsync(pictureToEdit);
            await _pictureRepository.SaveChangesAsync();
            return Ok(pictureToEdit);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            Picture picture = await _pictureRepository.GetByIdAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            await _pictureRepository.RemoveAsync(picture);
            await _pictureRepository.SaveChangesAsync();

            // Add a custom header with the updated item's id to the Http response
            Response.Headers.Append("Removed-Realtor-Firm-Id", picture.Id.ToString());
            // Return a lightweight success response
            return NoContent();
        }
    }
}
