namespace Echo_HemAPI.Data.Models.DTOs.PictureDtos
{

    //Author Gustaf
    public class PictureDto
    {
        public string PictureUrl { get; set; } = string.Empty;
        public int? EstateId { get; set; }
    }

    public class UpdatePictureDto
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; } = string.Empty;

        public int? EstateId { get; set; }
    }
}
