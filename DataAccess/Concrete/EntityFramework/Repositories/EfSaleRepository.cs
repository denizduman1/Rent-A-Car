﻿using DataAccess.Abstract;
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
    public class EfSaleRepository : EfEntityRepositoryBase<Sale>, ISaleRepository
    {
        public EfSaleRepository(DbContext context) : base(context)
        {
        }
    }
}
