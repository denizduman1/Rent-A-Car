using AutoMapper;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandAddDto, Brand>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest=>dest.ModifiedDate, opt=>opt.MapFrom(x=>DateTime.Now))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(x => false));

            CreateMap<BrandUpdateDto, Brand>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Brand, BrandUpdateDto>();
        }
    }
}
