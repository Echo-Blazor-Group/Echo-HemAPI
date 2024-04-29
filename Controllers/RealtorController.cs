using AutoMapper;
using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs.RealtorDTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Echo_HemAPI.Data.Repositories.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorController : ControllerBase
    {
        private readonly UserManager<Realtor> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RealtorController(UserManager<Realtor> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        // GET: api/<RealtorController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userManager.Users.Include(u => u.RealtorFirm).ToListAsync();
            if (users is not null && users.Count > 0)
            {
                var usersToDTOs = _mapper.Map<List<RealtorGetDTO>>(users);
                return Ok(usersToDTOs);
            }
            else
            {
                return NotFound("There are no registered users yet.");
            }
        }

        // GET api/<RealtorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            if (id.IsNullOrEmpty())
            {
                return NotFound("Invalid id.");
            }


            var user = await _userManager.Users.Include(u => u.RealtorFirm)
                                               .Where(u => u.Id == id)
                                               .FirstOrDefaultAsync();
            if (user is not null)
            {
                var userToDto = _mapper.Map<RealtorGetDTO>(user);
                return Ok(userToDto);
            }
            else
            {
                return NotFound("Invalid id.");
            }
        }

        // POST api/<RealtorController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Realtor user)
        {
            try
            {
                if (ModelState.IsValid && user.PasswordHash is not null)
                {
                    var realtor = new Realtor
                    {
                        UserName = user.UserName,
                        Email = user.Email

                    };
                    var createdUser = await _userManager.CreateAsync(realtor, user.PasswordHash);
                    if (createdUser.Succeeded)
                    {
                        return Ok(createdUser);
                    }
                    else
                    {
                        return StatusCode(500, createdUser.Errors);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<RealtorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync([FromRoute] string id, [FromBody] Realtor user)
        {
            if (id != user.Id)
            {
                return NotFound("Inconsistent id's.");
            }

            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.Users.Where(i => i.Id == id).FirstOrDefaultAsync();
                if (existingUser is not null && user.PasswordHash is not null)
                {
                    existingUser.Email = user.Email;
                    existingUser.UserName = user.UserName;

                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(existingUser);
                    var resultPasswordChange = await _userManager.ResetPasswordAsync(existingUser, resetToken, user.PasswordHash);

                    var result = await _userManager.UpdateAsync(existingUser);
                    return Ok(existingUser);
                }
                else
                {
                    return NotFound("Existing user doesn't exist and/or new user.PasswordHash is null.");
                }


            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // DELETE api/<RealtorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] string id)
        {
            if (id.IsNullOrEmpty())
            {
                return NotFound("Invalid id.");
            }


            var user = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user is not null)
            {
                var estatesMatchingRealtorId = await _context.Estates.Where(e => e.Realtor.Id == user.Id).ToListAsync();

                if (estatesMatchingRealtorId.Count > 0)
                {
                    foreach (var estate in estatesMatchingRealtorId)
                    {
                        estate.Realtor = null;
                    }
                }
                
                user.RealtorFirm = null;
                user.ProfilePicture = null;

                await _context.SaveChangesAsync();
                await _userManager.DeleteAsync(user);
                return Ok(user); //can return NoContent() which is a successcode 204 for deletion

            }
            else
            {
                return NotFound("Delete failed, user does not exist.");
            }
        }
    }
}
