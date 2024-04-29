using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models.DTOs
{
    /// <summary>
    /// Author: Samed Salman
    /// File contains several DTO-classes for different uses.
    /// </summary> 


    // No id in Post class because it is automatically set by EF Core
    public class RealtorFirmPostDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("About this firm")]
        public string RealtorFirmPresentation { get; set; } = string.Empty;
        public string? Logotype { get; set; } = string.Empty;
    }

    // Get class has id
    public class RealtorFirmGetDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("About this firm")]
        public string RealtorFirmPresentation { get; set; } = string.Empty;
        public string? Logotype { get; set; } = string.Empty;
    }

    // Put class has id
    public class RealtorFirmPutDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("About this firm")]
        public string RealtorFirmPresentation { get; set; } = string.Empty;
        public string? Logotype { get; set; } = string.Empty;
    }
}
