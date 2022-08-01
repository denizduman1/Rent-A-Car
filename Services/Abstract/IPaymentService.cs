using Entity.Concrete;
using Entity.Concrete.DTOs;
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
        public Task<IDataResult<PaymentDto>> Get(int paymentId);
        public Task<IDataResult<PaymentListDto>> GetAll();
        public Task<IDataResult<PaymentListDto>> GetAllByNonDeleted();
        public Task<IResult> Add(PaymentAddDto paymentAddDto);
        public Task<IResult> Update(PaymentUpdateDto paymentUpdateDto);
        public Task<IResult> Pay(int paymentId);
        public Task<IResult> Delete(int paymentId);
        public Task<IResult> HardDelete(int paymentId);
    }
}
