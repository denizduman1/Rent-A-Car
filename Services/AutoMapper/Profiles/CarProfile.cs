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
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarAddDto, Car>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(x => false))
                .ForMember(dest => dest.CurrentCount, opt => opt.MapFrom(x => x.TotalCount));

            CreateMap<CarUpdateDto, Car>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Car, CarUpdateDto>();
        }
    }
}
