using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{

    //Author Gustaf
    public class Estate
    {
        public int Id { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public string LivingArea { get; set; }
        [Required]
        public string NumberOfRooms { get; set; }
        [Required]
        public string BiArea { get; set; }
        [Required]
        public string PropertyArea { get; set; }
        [Required]
        public string MonthlyFee { get; set; }
        [Required]
        public string RunningCosts { get; set; }
        [Required]
        public string ConstructionDate { get; set; }
        [Required]
        public string PropertyDescription { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public string category { get; set; }

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
