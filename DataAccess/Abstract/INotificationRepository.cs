using Entity.Concrete;
using Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INotificationRepository : IEntityRepository<Notification>
    {
    }
}
