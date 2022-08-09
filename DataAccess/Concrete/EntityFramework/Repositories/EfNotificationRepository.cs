using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfNotificationRepository : EfEntityRepositoryBase<Notification>, INotificationRepository
    {
        public EfNotificationRepository(DbContext context) : base(context)
        {

        }
    }
}
