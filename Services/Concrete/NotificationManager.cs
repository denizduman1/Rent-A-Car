using AutoMapper;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Services.Abstract;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class NotificationManager : INotificationService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NotificationListDto> GetAll()
        {
            var notifications = await _unitOfWork.NotificationRepository.GetAllAsync();
            return new NotificationListDto
            {
                Notifications = notifications
            };           
        }

        public async Task<NotificationListDto> GetAllByNonDeleted()
        {
            var notifications = await _unitOfWork.NotificationRepository.GetAllAsync(n=>n.IsDeleted == false && n.IsRead == false);
            return new NotificationListDto
            {
                Notifications = notifications
            };
        }

        public async Task Add(NotificationAddDto notificationAddDto)
        {
            var notification = _mapper.Map<Notification>(notificationAddDto);
            await _unitOfWork.NotificationRepository.AddAsync(notification);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(NotificationUpdateDto notificationUpdateDto)
        {
            var result = await _unitOfWork.NotificationRepository.AnyAsync(n => n.ID == notificationUpdateDto.ID);
            if (result)
            {
                var oldNatification = await _unitOfWork.NotificationRepository.GetAsync(n => n.ID == notificationUpdateDto.ID);
                var notification = _mapper.Map<NotificationUpdateDto,Notification>(notificationUpdateDto,oldNatification);
                await _unitOfWork.NotificationRepository.UpdateAsync(notification);
                await _unitOfWork.SaveAsync();
            }
        }

        public Task Delete(int notificationId)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int notificationId)
        {
            throw new NotImplementedException();
        }
    }
}
