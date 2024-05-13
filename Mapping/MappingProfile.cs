using AutoMapper;
using Echo_HemAPI.Controllers;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using Echo_HemAPI.Data.Models.DTOs.EstateDtos;
using Echo_HemAPI.Data.Models.DTOs.PictureDtos;
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

            CreateMap<PictureDto, Picture>().ReverseMap();
            CreateMap<UpdatePictureDto, Picture>().ReverseMap();

            // Author: Samed Salman
            CreateMap<RealtorFirm, RealtorFirmWithIdDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPostDTO>().ReverseMap();

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
