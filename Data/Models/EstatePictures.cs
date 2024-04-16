namespace Echo_HemAPI.Data.Models
{
    public class EstatePictures
    {
        public int Id { get; set; }

        public virtual Estate Pictures { get; set; }
        public string PictureUrl { get; set; }
    }
}
