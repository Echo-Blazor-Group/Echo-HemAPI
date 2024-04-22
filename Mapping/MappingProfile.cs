using AutoMapper;
using Echo_HemAPI.Controllers;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;

namespace Echo_HemAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Estate, EstateDto>().ReverseMap();
            CreateMap<InsertEstateDto, Estate>().ReverseMap();
            CreateMap<UpdateEstateDto, Estate>().ReverseMap();

            // Author: Samed Salman
            CreateMap<RealtorFirm, RealtorFirmGetDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPostDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPutDTO>().ReverseMap();
        }


    }
}
//public County? County { get; set; }

//public string Address { get; set; } = string.Empty;

//public int StartingPrice { get; set; }

//public string LivingAreaKvm { get; set; } = string.Empty;

//public string NumberOfRooms { get; set; } = string.Empty;

//public string BiAreaKvm { get; set; } = string.Empty;

//public string EstateAreaKvm { get; set; } = string.Empty;

//public string MonthlyFee { get; set; } = string.Empty;

//public string RunningCosts { get; set; } = string.Empty;

//public string ConstructionDate { get; set; } = string.Empty;

//public string EstateDescription { get; set; } = string.Empty;

//public DateOnly? PublishDate { get; set; } = new DateOnly();