using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace Echo_HemAPI.Data.Models
{

    //Author Gustaf
    public class Estate
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public string LivingAreaKvm { get; set; } = string.Empty;
        [Required]
        public string NumberOfRooms { get; set; } = string.Empty;
        [Required]
        public string BiAreaKvm { get; set; } = string.Empty;
        [Required]
        public string EstateAreaKvm { get; set; } = string.Empty;
        [Required]
        public string MonthlyFee { get; set; } = string.Empty;
        [Required]
        public string RunningCosts { get; set; } = string.Empty;
        [Required]
        public string ConstructionDate { get; set; } = string.Empty;
        [Required]
        public string EstateDescription { get; set; } = string.Empty;
        [Required]
        public DateOnly? PublishDate { get; set; } = new DateOnly();


        //Relational
        public County? County { get; set; }
        public Realtor? Realtor { get; set; }
        public Category? Category { get; set; }
        public List<Picture?>? Pictures { get; set; }


    }
}
