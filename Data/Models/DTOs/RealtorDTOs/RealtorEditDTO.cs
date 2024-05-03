using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
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
        public string ProfilePicture { get; set; } = "https://placehold.co/600x400/png";
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
