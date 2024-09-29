using AutoMapper;
using EmailAPI.Models;

namespace EmailAPI.DTOs.Mapping_profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmailDTO, Email>();
            CreateMap<Email, EmailResponseDTO>()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => src.Importance.ToString()));
        }
    }
}
