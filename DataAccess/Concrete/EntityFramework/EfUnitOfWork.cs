using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EfUnitOfWork(RentCarContext context)
        {
            _context = context;
        }

        private readonly IBrandRepository _brandRepository;

        private readonly ICarModelRepository _carModelRepository;

        private readonly ICarRepository _carRepository;

        private readonly IColorRepository _colorRepository;

        private readonly ICommentRepository _commentRepository;

        private readonly IPaymentRepository _paymentRepository;


        public IBrandRepository BrandRepository => _brandRepository ?? new EfBrandRepository(_context);
        public ICarModelRepository CarModelRepository => _carModelRepository ?? new EfCarModelRepository(_context);
        public ICarRepository CarRepository => _carRepository ?? new EfCarRepository(_context);
        public IColorRepository ColorRepository => _colorRepository ?? new EfColorRepository(_context);
        public ICommentRepository CommentRepository => _commentRepository ?? new EfCommentRepository(_context);
        public IPaymentRepository PaymentRepository => _paymentRepository ?? new EfPaymentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
