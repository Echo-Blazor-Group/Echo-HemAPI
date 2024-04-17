using Echo_HemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.Helper
{
    //Author Gustaf
    public static class SeedEstates
    {
        private static readonly County countys = new County();
        private static readonly Category Categories = new Category();

        public static Estate[] GetEstates()
        {
            // Seed data for Estates
            return new[]
            {
                new Estate
                {
                    Id = 1,
                    Address = "123 Main St",
                    StartingPrice = 200000,
                    LivingAreaKvm = "150",
                    NumberOfRooms = "3",
                    BiAreaKvm = "50",
                    EstateAreaKvm = "200",
                    MonthlyFee = "3000",
                    RunningCosts = "1000",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "A beautiful house near the park.",
                    PublishDate = new DateOnly(2024, 4, 16),


                },
                new Estate
                {
                    Id= 2,
                    Address = "789 Oak Avenue",
                    StartingPrice = 250000,
                    LivingAreaKvm = "180",
                    NumberOfRooms = "5",
                    BiAreaKvm = "60",
                    EstateAreaKvm = "240",
                    MonthlyFee = "3200",
                    RunningCosts = "1100",
                    ConstructionDate = "2015-09-20",
                    EstateDescription = "Spacious modern house with a backyard pool",
                    PublishDate = new DateOnly(2024, 4, 16),
                },
                new Estate
                {
                    Id = 3,
                    Address = "458 Elm Street",
                    StartingPrice = 180000,
                    LivingAreaKvm = "110",
                    NumberOfRooms = "4",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "160",
                    MonthlyFee = "1800",
                    RunningCosts = "900",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "Cozy family home near the lake",
                    PublishDate = new DateOnly(2024, 4, 16), // Not specified

                },
                new Estate
                {
                    Id = 4,
                    Address = "456 Allsm Street",
                    StartingPrice = 180000,
                    LivingAreaKvm = "120",
                    NumberOfRooms = "5",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "160",
                    MonthlyFee = "2800",
                    RunningCosts = "900",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "Cozy family home near the lake",
                    PublishDate = new DateOnly(2024, 4, 16), // Not specified

                },
                new Estate
                {
                    Id = 5,
                    Address = "23 Oak Avenue",
                    StartingPrice = 250000,
                    LivingAreaKvm = "280",
                    NumberOfRooms = "7",
                    BiAreaKvm = "60",
                    EstateAreaKvm = "240",
                    MonthlyFee = "4200",
                    RunningCosts = "2100",
                    ConstructionDate = "2015-09-20",
                    EstateDescription = "Spacious modern house with a backyard pool",
                    PublishDate = new DateOnly(2024, 4, 16),

                },
                new Estate
                {
                    Id = 6,
                    Address = "12 Chuckni Street",
                    StartingPrice = 180000,
                    LivingAreaKvm = "120",
                    NumberOfRooms = "4",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "160",
                    MonthlyFee = "2800",
                    RunningCosts = "900",
                    ConstructionDate = "2024-01-01",
                    EstateDescription = "Cozy family home near the lake",
                    PublishDate = new DateOnly(2024, 4, 16), // Not specified

                },
                new Estate
                {
                    Id = 7,
                    Address = "101 Maple Lane",
                    StartingPrice = 300000,
                    LivingAreaKvm = "200",
                    NumberOfRooms = "6",
                    BiAreaKvm = "80",
                    EstateAreaKvm = "280",
                    MonthlyFee = "3500",
                    RunningCosts = "1200",
                    ConstructionDate = "2010-12-10",
                    EstateDescription = "Elegant colonial-style home with a garden",
                    PublishDate = new DateOnly(2024, 4, 16),

                },
                new Estate
                {
                    Id = 8,
                    Address = "Strandvägen 8",
                    StartingPrice = 7500000,
                    LivingAreaKvm = "220",
                    NumberOfRooms = "7",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "260",
                    MonthlyFee = "8000",
                    RunningCosts = "2000",
                    ConstructionDate = "2010-03-20",
                    EstateDescription = "Luxurious waterfront villa with private dock",
                    PublishDate = new DateOnly(2024, 4, 16),

                },
                new Estate
                {
                    Id = 9,
                    Address = "Storgatan 12",
                    StartingPrice = 2200000,
                    LivingAreaKvm = "150",
                    NumberOfRooms = "5",
                    BiAreaKvm = "30",
                    EstateAreaKvm = "180",
                    MonthlyFee = "4000",
                    RunningCosts = "1500",
                    ConstructionDate = "2008-06-15",
                    EstateDescription = "Modern townhouse in the heart of Stockholm",
                    PublishDate = new DateOnly(2024, 4, 16),

                },
                new Estate
                {
                    Id = 10,
                    Address = "Björkgatan 15",
                    StartingPrice = 1850000,
                    LivingAreaKvm = "100",
                    NumberOfRooms = "4",
                    BiAreaKvm = "20",
                    EstateAreaKvm = "120",
                    MonthlyFee = "2800",
                    RunningCosts = "1100",
                    ConstructionDate = "2005-04-22",
                    EstateDescription = "Cozy townhouse with a small garden",
                    PublishDate = new DateOnly(2024, 4, 16),

                },
                new Estate
                {
                    Id = 11,
                    Address = "Lärkstigen 7",
                    StartingPrice = 3200000,
                    LivingAreaKvm = "230",
                    NumberOfRooms = "6",
                    BiAreaKvm = "50",
                    EstateAreaKvm = "230",
                    MonthlyFee = "4500",
                    RunningCosts = "1800",
                    ConstructionDate = "2012-09-10",
                    EstateDescription = "Spacious family home in a quiet neighborhood",
                    PublishDate = new DateOnly(2024, 4, 16),

                }
            };

            // Add more Estate instances as needed

        }
    }
}
