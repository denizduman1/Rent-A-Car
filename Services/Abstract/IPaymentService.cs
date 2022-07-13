using Entity.Concrete;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IPaymentService
    {
        public Task<IDataResult<Payment>> Get(int paymentId);
        public Task<IDataResult<IList<Payment>>> GetAll();
        public Task<IDataResult<IList<Payment>>> GetAllByNonDeleted();
        public Task<IResult> Add(Payment payment);
        public Task<IResult> Update(Payment payment);
        public Task<IResult> Delete(int paymentId);
        public Task<IResult> HardDelete(int paymentId);
    }
}
