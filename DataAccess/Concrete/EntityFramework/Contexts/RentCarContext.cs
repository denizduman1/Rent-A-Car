﻿using DataAccess.Concrete.EntityFramework.Mappings;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class RentCarContext : DbContext
    {
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<CarModel>? CarModels { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<Sale>? Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLOCALDB;Database=RentCar;Trusted_Connection=True;Connect
            Timeout=30;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new CarModelMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
        }
    }
}
