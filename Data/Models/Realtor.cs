using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{
    public class Realtor : IdentityUser
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; } = string.Empty;

        

    }
}
