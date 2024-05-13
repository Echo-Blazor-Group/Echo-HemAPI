using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echo_HemAPI.Data.Models
{
    public class Picture
    {
        //Author Gustaf
        public int Id { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        //EstateId is nullable because otherwise the DbSeeder will not work. But in the end a picture will always be created 
        //directly to houses unless created in the database itself.
        public int? EstateId { get; set; }
    }
}
