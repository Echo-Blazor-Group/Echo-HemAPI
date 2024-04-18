namespace Echo_HemAPI.Data.Models
{
    public class Picture
    {
        //Author Gustaf & Seb
        public int Id { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public int? EstateId { get; set; }
        public string? RealtorId { get; set; }
        public int? RealtorFirmId { get; set; }
        
    }
}
