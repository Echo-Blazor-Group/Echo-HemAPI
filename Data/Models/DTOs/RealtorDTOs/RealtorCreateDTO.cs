using static System.Net.WebRequestMethods;

namespace Echo_HemAPI.Data.Models.DTOs.RealtorDTOs
{
    public class RealtorCreateDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RealtorFirmName { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = "https://placehold.co/600x400/png";
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        
    }
}
