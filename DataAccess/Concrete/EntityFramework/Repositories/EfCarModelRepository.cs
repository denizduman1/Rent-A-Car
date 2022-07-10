using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Abstract;
using Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCarModelRepository : EfEntityRepositoryBase<CarModel>, ICarModelRepository
    {
        public EfCarModelRepository(DbContext context) : base(context)
        {
        }
    }
}
