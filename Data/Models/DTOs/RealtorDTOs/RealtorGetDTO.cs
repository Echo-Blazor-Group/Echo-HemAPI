using System.ComponentModel;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    //Author: Seb
    public class RealtorGetDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RealtorFirmName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = "https://shorturl.at/CJOR3";
        public bool IsActive { get; set; }
    }
}
