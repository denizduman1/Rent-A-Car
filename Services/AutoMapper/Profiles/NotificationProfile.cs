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
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationAddDto, Notification>().
                 ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(x => false)); 

            CreateMap<NotificationUpdateDto, Notification>().
                 ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.UtcNow));

            CreateMap<Notification,NotificationUpdateDto>();
        }
    }
}
