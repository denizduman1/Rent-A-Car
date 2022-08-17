using AutoMapper;
using DataAccess.Abstract;
using Entity.Concrete;
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

        public PaymentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(PaymentAddDto paymentAddDto)
        {
            var payment = _mapper.Map<Payment>(paymentAddDto);
            await _unitOfWork.PaymentRepository.AddAsync(payment);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"Araç başarıyla kiralanmıştır");
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

        public async Task<IResult> Update(PaymentUpdateDto paymentUpdateDto)
        {
            var result = await _unitOfWork.PaymentRepository.AnyAsync();
            if (result)
            {
                var oldPayment = await _unitOfWork.PaymentRepository.GetAsync(p => p.ID == paymentUpdateDto.ID);
                var payment = _mapper.Map<PaymentUpdateDto, Payment>(paymentUpdateDto, oldPayment);
                await _unitOfWork.PaymentRepository.UpdateAsync(payment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"Başarıyla Güncellendi");
            }
            return new Result(ResultStatus.Error, message: $"Güncellemek istediğiniz kiralama bulunamamaktadır.");
        }
        public async Task<IResult> UpdateBatch(Payment payment)
        {
            var result = await _unitOfWork.PaymentRepository.AnyAsync();
            if (result)
            {
                var oldPayment = await _unitOfWork.PaymentRepository.GetAsync(p => p.ID == payment.ID);
                oldPayment.ModifiedDate = payment.ModifiedDate;
                oldPayment.IsCancelled = payment.IsCancelled;
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"Başarıyla Güncellendi");
            }
            return new Result(ResultStatus.Error, message: $"Güncellemek istediğiniz kiralama bulunamamaktadır.");
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
