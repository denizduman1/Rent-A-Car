using AutoMapper;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Services.Abstract;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IResult> Add(PaymentAddDto paymentAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PaymentDto>> Get(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PaymentListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<PaymentListDto>> GetAllByNonDeleted()
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllAsync(p=>p.IsDeleted == false,
                p=>p.Car, p=>p.User, p=>p.Car.CarModel, p=>p.Car.CarModel.Brand);
            if (payments.Count>0)
            {
                return new DataResult<PaymentListDto>(new PaymentListDto { Payments = payments, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<PaymentListDto>(new PaymentListDto
            {
                Payments = payments,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş kiralama bulunamadı"
            }, ResultStatus.Error);
        }

        public Task<IResult> HardDelete(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(PaymentUpdateDto paymentUpdateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Pay(int paymentId)
        {
            var payment = await _unitOfWork.PaymentRepository.GetAsync(p=>p.ID == paymentId);
            payment.IsPaid = true;
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }
    }
}
