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
            // Author: Gustaf Von Schélee frejd
            CreateMap<Estate, EstateDto>().ReverseMap();

            CreateMap<InsertEstateDto, Estate>().ReverseMap();

            CreateMap<UpdateEstateDto, Estate>()
                //.ForMember(dest => dest.Realtor.Id, opt => opt.MapFrom(src => src.RealtorId))
                //.ForMember(dest => dest.County.Id, opt => opt.MapFrom(src => src.CountyId))
                //.ForMember(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap();

            // Author: Samed Salman
            CreateMap<RealtorFirm, RealtorFirmGetDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPostDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPutDTO>().ReverseMap();

            // Author: Seb
            CreateMap<Realtor, RealtorGetDTO>().ForMember(dest => dest.RealtorFirmName,
                                      opt => opt.MapFrom(src => src.RealtorFirm.Name)).ReverseMap();



            CreateMap<Realtor, RealtorCreateDTO>().ForMember(dest => dest.RealtorFirmId,
                                      opt => opt.MapFrom(src => src.RealtorFirm.Id))
                                                   .ForMember(dest => dest.Email, opt => opt
                                                   .MapFrom(src => src.UserName))
                                                   .ReverseMap();



            CreateMap<RealtorEditDTO, Realtor>().ForMember(dest => dest.UserName,
                                                opt => opt.MapFrom(src => src.Email)).ReverseMap();
        }


    }
}
