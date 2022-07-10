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
    public class EfCarRepository : EfEntityRepositoryBase<Car>, ICarRepository
    {
        public EfCarRepository(DbContext context) : base(context)
        {
        }
    }
}
