using AutoMapper;
using Echo_HemAPI.Controllers;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Models.DTOs.RealtorDTOs;

namespace Echo_HemAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Author: Gustaf Von Schélee
            CreateMap<Estate, EstateDto>().ReverseMap();
            CreateMap<InsertEstateDto, Estate>().ReverseMap();
            CreateMap<UpdateEstateDto, Estate>().ReverseMap();

            // Author: Samed Salman
            CreateMap<RealtorFirm, RealtorFirmGetDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPostDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPutDTO>().ReverseMap();

            // Author: Seb
            CreateMap<Realtor, RealtorGetDTO>().ForMember(dest => dest.RealtorFirmName,
                                             opt => opt.MapFrom(src => src.RealtorFirm.Name));
        }


    }
}
