using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>
    public class RealtorFirm
    {
        public int RealtorFirmId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("About this firm")]
        public string RealtorFirmPresentation { get; set; } = string.Empty;
        [DisplayName("Logotype")]
        public string LogotypeURL { get; set; } = string.Empty;
        // List of the firm's employees
        public List<Realtor>? Employees { get; set; }
        // List of estates brokered by the firm
        public List<Estate>? Estates { get; set; }
    }
}
