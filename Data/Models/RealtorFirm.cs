using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{
    public class RealtorFirm
    {
        public int RealtorFirmId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RealtorFirmDescription { get; set; }
        public string LogotypeURL { get; set; }
        // List of the firm's employees
        public List<Realtor> Employees { get; set; }
        // List of estates brokered by the firm
        public List<Estate> Estates { get; set; }
    }
}
