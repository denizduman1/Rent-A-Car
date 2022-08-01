using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBrandRepository BrandRepository { get; }
        ICarModelRepository CarModelRepository { get; }
        ICarRepository CarRepository { get; }
        IColorRepository ColorRepository { get; }
        ICommentRepository CommentRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        Task<int> SaveAsync();
    }
}
