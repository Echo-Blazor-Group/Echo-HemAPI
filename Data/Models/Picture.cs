using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echo_HemAPI.Data.Models
{
    public class Picture
    {
        //Author Gustaf & Seb
        public int Id { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        
        public int? EstateId { get; set; }
    }
}
