using AutoMapper;
using Entity.Concrete;
using Entity.Concrete.DTOs;

namespace Services.AutoMapper.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAddDto, Color>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(x => false));

            CreateMap<ColorAddDto, Color>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
