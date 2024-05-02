using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    public class RealtorLoginDTO
    {
        [Required]
        public string Email { get;set; }
        [Required]
        public string Password { get;set; } 
    }
}
