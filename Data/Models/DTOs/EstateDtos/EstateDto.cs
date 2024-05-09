﻿using Microsoft.CodeAnalysis.CSharp;

namespace Echo_HemAPI.Data.Models.DTOs.EstateDtos
{
    //Author Gustaf
    public class EstateDto
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

        public bool OnTheMarket { get; set; }
        //Relational

        public Realtor? Realtor { get; set; }
        public County? County { get; set; }
        public Category? Category { get; set; }
        public List<Picture> Pictures { get; set; }
        
        public void PicturesInBox()
        {
            foreach (var picture in Pictures)
            {
                
            }
        }

    }
}