using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{

    //Author Gustaf
    public class Estate
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public string LivingAreaKvm { get; set; }
        [Required]
        public string NumberOfRooms { get; set; }
        [Required]
        public string BiAreaKvm { get; set; }
        [Required]
        public string EstateAreaKvm { get; set; }
        [Required]
        public string MonthlyFee { get; set; }
        [Required]
        public string RunningCosts { get; set; }
        [Required]
        public string ConstructionDate { get; set; }
        [Required]
        public string EstateDescription { get; set; }
        [Required]
        //Creater a new class for image storage
        public string Images { get; set; }
        [Required]
        public string Category { get; set; }

        //Relational
        public County County { get; set; }
        public Realtor Realtor { get; set; }

        //Method for Getting the Categories
        public void Categories()
        {
            string[] categories = new string[]
            {
                "Bostadsrättslägenhet", "Bostadsrättsradhus", "Villa", "Fritidshus"
            };
        }

    }
}
