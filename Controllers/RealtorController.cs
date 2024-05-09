using AutoMapper;
using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs.RealtorDTOs;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Echo_HemAPI.Data.Repositories.Repos;
using Echo_HemAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Echo_HemAPI.Controllers
{
    //Author: Seb

    [Route("api/[controller]")]
    [ApiController]
    public class RealtorController : ControllerBase
    {
        private readonly UserManager<Realtor> _userManager;
        private readonly SignInManager<Realtor> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IRealtorFirmRepository _realtorFirmRepo;
        private readonly IEstateRepository _estateRepo;
        private readonly IMapper _mapper;

        public RealtorController(UserManager<Realtor> userManager, SignInManager<Realtor> signInManager,
                                 ITokenService tokenService, IMapper mapper,
                                 IRealtorFirmRepository realtorFirmRepo, IEstateRepository estateRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _realtorFirmRepo = realtorFirmRepo;
            _estateRepo = estateRepo;
        }

        // GET: api/<RealtorController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryObject query)
        {
            var users = _userManager.Users.Include(u => u.RealtorFirm).AsQueryable();

            if (!users.Any())
            {
                return NotFound("There are no registered users yet.");
            }

            var filteredList = await QueryObject.FilterByQuery(users, query);

            if (filteredList is not null)
            {
                var usersToDTOs = _mapper.Map<List<RealtorGetDTO>>(filteredList);
                return Ok(usersToDTOs);
            }
            else
            {
                return NotFound("No users match the filter.");
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(RealtorLoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var realtor = await _userManager.Users.Include(r => r.RealtorFirm).Where(r => r.Email == loginDTO.Email.ToLower()).FirstOrDefaultAsync();

            if (realtor is null)
                return Unauthorized("Invalid email.");

           var result = await _signInManager.CheckPasswordSignInAsync(realtor, loginDTO.Password, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(realtor);
                var role = roles.FirstOrDefault();
                return Ok(new NewUserShowClaimsDTO
                {
                    Email = realtor.Email,
                    UserName = realtor.Email,
                    RealtorFirmId = realtor.RealtorFirm!.Id,
                    Role = role,
                    Token = _tokenService.CreateToken(realtor,realtor.RealtorFirm.Id, role)
                });
            }
            else
            {
                return Unauthorized("Invalid email and/or password.");
            }
        }

        // POST api/<RealtorController>
        [HttpPost("register")]
        public async Task<IActionResult> AddAsync([FromBody] RealtorCreateDTO createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var realtorFromDto = _mapper.Map<Realtor>(createDTO);
                var existingRealtorFirm = await _realtorFirmRepo.GetByIdAsync(createDTO.RealtorFirmId);
                if (existingRealtorFirm is null)
                {
                    return StatusCode(500, "Must connect realtor to existing realtor firm.");
                }
                else
                {
                    realtorFromDto.RealtorFirm = existingRealtorFirm;
                }
                if (realtorFromDto.ProfilePicture.IsNullOrEmpty() || realtorFromDto.ProfilePicture.ToLower() == "string")
                    realtorFromDto.ProfilePicture = "https://shorturl.at/CJOR3";


                var createdUser = await _userManager.CreateAsync(realtorFromDto, createDTO.Password!);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(realtorFromDto, SD.Realtor);
                    if (roleResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(realtorFromDto);
                        var role = roles.FirstOrDefault();
                        return Ok(
                            new NewUserShowClaimsDTO
                            {
                                Email = realtorFromDto.Email,
                                UserName = realtorFromDto.Email,
                                RealtorFirmId = realtorFromDto.RealtorFirm.Id,
                                Role = role,
                                Token = _tokenService.CreateToken(realtorFromDto,
                                                      realtorFromDto.RealtorFirm.Id, role)
                            }
                         );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<RealtorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync([FromRoute] string id, [FromBody] RealtorEditDTO editDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingRealtor = await _userManager.FindByIdAsync(id);
                if (existingRealtor is null)
                    return NotFound("User not found");

                if (editDTO.OldPassword.IsNullOrEmpty() || editDTO.NewPassword.IsNullOrEmpty() ||
                    editDTO.OldPassword.ToLower().Equals("string") ||
                    editDTO.NewPassword.ToLower().Equals("string"))
                {
                    _mapper.Map(editDTO, existingRealtor);
                    var updateResult = await _userManager.UpdateAsync(existingRealtor);
                    if (updateResult.Succeeded)
                    {
                        return Ok("User edited successfully.");
                    }
                    else
                    {
                        return StatusCode(500, updateResult.Errors);
                    }
                }
                else
                {

                    bool checkResult = await _userManager.CheckPasswordAsync(existingRealtor, editDTO.OldPassword);

                    if (!checkResult)
                        return StatusCode(500, "Incorrect password");

                    var passwordChangeResult = await _userManager.ChangePasswordAsync(existingRealtor,
                                                        editDTO.OldPassword, editDTO.NewPassword);
                    if (passwordChangeResult.Succeeded)
                    {
                        _mapper.Map(editDTO, existingRealtor);

                        var updateResult = await _userManager.UpdateAsync(existingRealtor);
                        if (updateResult.Succeeded)
                        {
                            return Ok("User edited & password changed successfully.");
                        }
                        else
                        {
                            return StatusCode(500, updateResult.Errors);
                        }

                    }
                    else
                    {
                        return StatusCode(500, passwordChangeResult.Errors);
                    }
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        // DELETE api/<RealtorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] string id, [FromQuery] DeleteQueryObject query)
        {
            if (id.IsNullOrEmpty())
                return NotFound("Invalid id.");

            if (query.Remove is null)
                return BadRequest("Cannot continue; realtor must either be deleted or deactivated.");

            var user = await _userManager.FindByIdAsync(id);

            if (user is not null && query.Remove is false)
            {
                user.IsActive = false;
                var saveResult = await _userManager.UpdateAsync(user);
                if (saveResult.Succeeded)
                {
                    return Ok("Realtor deactivated.");
                }
                else
                {
                    return StatusCode(500, saveResult.Errors);
                }

            }


            if (user is not null && query.Remove is true)
            {
                var estatesMatchingThisRealtorId = await _estateRepo.GetAllAsync();

                estatesMatchingThisRealtorId.AsQueryable();

                var filteredEstates = estatesMatchingThisRealtorId.Where(e => e.Realtor?.Id == user.Id);


                if (filteredEstates.Any())
                {
                    foreach (var estate in filteredEstates)
                    {
                        estate.Realtor = null;
                    }
                }

                user.RealtorFirm = null;

                await _estateRepo.SaveChangesAsync();
                var deleteResult = await _userManager.DeleteAsync(user);
                if (deleteResult.Succeeded)
                {
                    return Ok("Realtor deleted and linked estates have had their realtor properties nulled.");
                }
                else
                {
                    return StatusCode(500, deleteResult.Errors);
                }


            }
            else
            {
                return NotFound("Delete failed, user does not exist.");
            }
        }
    }
}
