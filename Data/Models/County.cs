using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{
    public class County
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("County")]
        public string CountyName { get; set; } = string.Empty;
        
    }
}
