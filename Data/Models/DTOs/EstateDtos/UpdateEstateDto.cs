namespace Echo_HemAPI.Data.Models.DTOs.EstateDtos
{
    public class UpdateEstateDto
    {
        //Id needed for finding the correct object via the api updating endpoint.
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
        //bool for setting of the object should show up on lists or not.
        public bool OnTheMarket { get; set; } = true;

        //Relational forgine keys because this is an update object
        //and only needs to change the Id of what ever object it should be connected to
        public int CountyId { get; set; }
        public int CategoryId { get; set; }
        public string? RealtorId { get; set; }

    }
}
