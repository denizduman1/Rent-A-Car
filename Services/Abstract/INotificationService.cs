using Entity.Concrete.DTOs;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface INotificationService
    {
        public Task<NotificationListDto> GetAll();
        public Task<NotificationListDto> GetAllByNonDeleted();
        public Task Add(NotificationAddDto notificationAddDto);
        public Task Update(NotificationUpdateDto notificationUpdateDto);
        public Task Delete(int notificationId);
        public Task HardDelete(int notificationId);
    }
}
