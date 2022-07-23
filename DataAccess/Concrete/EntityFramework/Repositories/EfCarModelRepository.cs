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
        private readonly DbContext _context;

        public EfCarModelRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CarModel> AddWithReturn(CarModel carModel)
        {
            await _context.Set<CarModel>().AddAsync(carModel);
            return carModel;
        }
    }
}
