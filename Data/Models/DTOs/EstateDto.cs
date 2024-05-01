﻿using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Data.Models.DTOs
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
        //Relational

        public Realtor? Realtor { get; set; }
        public County? County { get; set; } 
        public Category? Category { get; set; }
        public List<Picture?>? Pictures { get; set; }
    }

    public class EstatePutDto
    {

    }

    public class EstatePostDto
    {

    }
    public class EstateDeleteDto
    {
    }
}


//estateExists.Address = estate.Address;
//estateExists.StartingPrice = estate.StartingPrice;
//estateExists.LivingAreaKvm = estate.LivingAreaKvm;
//estateExists.NumberOfRooms = estate.NumberOfRooms;
//estateExists.BiAreaKvm = estate.BiAreaKvm;
//estateExists.EstateAreaKvm = estate.EstateAreaKvm;
//estateExists.MonthlyFee = estate.MonthlyFee;
//estateExists.RunningCosts = estate.RunningCosts;
//estateExists.ConstructionDate = estate.ConstructionDate;
//estateExists.EstateDescription = estate.EstateDescription;
//estateExists.PublishDate = estate.PublishDate;
//estateExists.Realtor = estate.Realtor;
//estateExists.Category = estate.Category;
//estateExists.County = estate.County;
//estateExists.Pictures = estate.Pictures;