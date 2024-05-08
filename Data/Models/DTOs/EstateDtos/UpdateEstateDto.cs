namespace Echo_HemAPI.Data.Models.DTOs.EstateDtos
{
    public class UpdateEstateDto
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public int StartingPrice { get; set; }

        public string LivingAreaKvm { get; set; } = string.Empty;

        public string NumberOfRooms { get; set; } = string.Empty;

        public string BiAreaKvm { get; set; } = string.Empty;

        public string EstateAreaKvm { get; set; } = string.Empty;

        public string MonthlyFee { get; set; } = string.Empty;

        public string RunningCosts { get; set; } = string.Empty;

        public string ConstructionDate { get; set; } = string.Empty;

        public string EstateDescription { get; set; } = string.Empty;

        public DateOnly? PublishDate { get; set; } = new DateOnly();
        public bool OnTheMarket { get; set; } = true;
        //Relational
        public int CountyId { get; set; }
        public int CategoryId { get; set; }
        public string? RealtorId { get; set; }

    }
}
