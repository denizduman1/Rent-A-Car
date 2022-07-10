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
    public class EfPaymentRepository : EfEntityRepositoryBase<Payment>, IPaymentRepository
    {
        public EfPaymentRepository(DbContext context) : base(context)
        {
        }
    }
}
