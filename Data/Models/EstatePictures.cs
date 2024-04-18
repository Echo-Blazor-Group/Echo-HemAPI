namespace Echo_HemAPI.Data.Models
{
    public class EstatePictures
    {
        public int EstateId { get; set; }
        public int PictureId { get; set; }

        public Estate Estate { get; set; }
        public Picture Picture { get; set; }
    }
}
