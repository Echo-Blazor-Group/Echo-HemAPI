using System.ComponentModel;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    public class RealtorGetDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RealtorFirmName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
