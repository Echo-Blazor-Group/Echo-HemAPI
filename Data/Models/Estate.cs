using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{

    //Author Gustaf
    public class Estate
    {
        //reminder to change some of the values into int´s instead to make it easier for people adding data to just add resonable data
        //this is optional ofc..
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public int LivingAreaKvm { get; set; } 
        [Required]
        public int NumberOfRooms { get; set; } 
        [Required]
        public int BiAreaKvm { get; set; } 
        [Required]
        public int EstateAreaKvm { get; set; } 
        [Required]
        public int MonthlyFee { get; set; }
        [Required]
        public int RunningCosts { get; set; }
        [Required]
        public DateOnly? ConstructionDate { get; set; }
        [Required]
        public string EstateDescription { get; set; } = string.Empty;
        [Required]
        public DateOnly? PublishDate { get; set; } = new DateOnly();
        public bool OnTheMarket { get; set; } = true;

        //Relational
        public County? County { get; set; }
        public Realtor? Realtor { get; set; }
        public Category? Category { get; set; }
        public List<Picture> Pictures { get; set; }


    }
}
