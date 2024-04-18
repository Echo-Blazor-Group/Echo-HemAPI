namespace Echo_HemAPI.Data.Models
{
    public class EstateRealtor
    {
        public int EstateId { get; set; }
        public int RealtorId { get; set; }

        public Estate Estate { get; set; }
        public Realtor Realtor { get; set; }


    }
}
