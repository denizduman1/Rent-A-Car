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
    public class CarManager : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CarAddDto carAddDto)
        {
            var car = _mapper.Map<Car>(carAddDto);
            await _unitOfWork.CarRepository.AddAsync(car);
            await _unitOfWork.SaveAsync();
            var carModel = await _unitOfWork.CarModelRepository.GetAsync(c=>c.ID == carAddDto.CarModelId,c=>c.Brand);
            return new Result(ResultStatus.Success, message: $"{carModel?.Brand?.Name} {carModel?.Name} adlı araç başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(int carId)
        {
            var result = await _unitOfWork.CarRepository.AnyAsync(b => b.ID == carId);
            if (result)
            {
                var car = await _unitOfWork.CarRepository.GetAsync(b => b.ID == carId, c=>c.CarModel, c=>c.CarModel.Brand);
                car.IsDeleted = true;
                await _unitOfWork.CarRepository.UpdateAsync(car);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{car.CarModel.Brand.Name} {car.CarModel.Name} adlı araç başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz araç bilgisi bulunamamaktadır.");
        }

        public async Task<IDataResult<CarDto>> Get(int carId)
        {
            var car = await _unitOfWork.CarRepository.GetAsync(b => b.ID == carId);
            if (car is not null)
            {
                return new DataResult<CarDto>(new CarDto { Car = car, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarDto>(new CarDto { Car = car, ResultStatus = ResultStatus.Error, Message = "İlgili araç bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IDataResult<CarListDto>> GetAll()
        {
            var cars = await _unitOfWork.CarRepository.GetAllAsync();
            if (cars.Count>0)
            {
                return new DataResult<CarListDto>(new CarListDto { Cars = cars, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarListDto>(new CarListDto { Cars = cars, ResultStatus = ResultStatus.Error, Message = "İlgili araç bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IDataResult<CarListDto>> GetAllByNonDeleted()
        {
            var cars = await _unitOfWork.CarRepository.GetAllAsync(c=>c.IsDeleted == false, c=>c.CarModel, c=>c.Color ,c=>c.CarModel.Brand);
            if (cars.Count > 0)
            {
                return new DataResult<CarListDto>(new CarListDto { Cars = cars, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarListDto>(new CarListDto { Cars = cars, ResultStatus = ResultStatus.Error, Message = "Silinmemiş araç bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IResult> HardDelete(int carId)
        {
            var result = await _unitOfWork.CarRepository.AnyAsync(b => b.ID == carId);
            if (result)
            {
                var car = await _unitOfWork.CarRepository.GetAsync(b => b.ID == carId);
                await _unitOfWork.CarRepository.RemoveAsync(car);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{car.CarModel.Brand.Name} {car.CarModel.Name} adlı araç başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz marka bilgisi bulunamamaktadır.");
        }

        public async Task<IResult> Update(CarUpdateDto carUpdateDto)
        {
            var result = await _unitOfWork.CarRepository.AnyAsync(b => b.ID == carUpdateDto.ID);
            if (result)
            {
                var car = _mapper.Map<Car>(carUpdateDto);
                await _unitOfWork.CarRepository.UpdateAsync(car);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{car.CarModel.Brand.Name} {car.CarModel.Name} adlı araç başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Success, $"Güncellemek istediğiniz marka bilgisi bulunamamaktadır.");
        }
    }
}
