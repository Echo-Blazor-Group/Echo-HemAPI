using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models.DTOs
{
    //Author Seb
    public class RealtorDto
    {
        public RealtorDto()
        {

        }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int? RealtorFirmId { get; set; }

        [Required]
        public string? ProfilePicture { get; set; }
    }
}
