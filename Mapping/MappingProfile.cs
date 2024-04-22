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
            // Author: Gustaf Von Schélee
            CreateMap<Estate, EstateDto>()
                .ForMember(s => s.Address, o => o.MapFrom(svm => svm.Address))
                .ForMember(s => s.NumberOfRooms, o => o.MapFrom(svm => svm.NumberOfRooms))
                .ReverseMap();

            // Author: Samed Salman
            CreateMap<RealtorFirm, RealtorFirmGetDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPostDTO>().ReverseMap();
            CreateMap<RealtorFirm, RealtorFirmPutDTO>().ReverseMap();
        }


    }
}
