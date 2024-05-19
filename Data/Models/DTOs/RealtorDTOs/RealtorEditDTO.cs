using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    //Author: Seb
    public class RealtorEditDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required]
        public string ProfilePicture { get; set; } = "https://shorturl.at/CJOR3";
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
