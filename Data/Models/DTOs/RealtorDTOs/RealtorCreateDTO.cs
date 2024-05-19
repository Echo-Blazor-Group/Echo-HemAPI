using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    //Author: Seb
    public class RealtorCreateDTO
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
        public string? Password { get; set; }
        [Required]
        public int RealtorFirmId { get; set; }
        public string ProfilePicture { get; set; } = "https://shorturl.at/CJOR3";
        
        
    }
}
