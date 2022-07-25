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
    public class CarModelManager : ICarModelService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarModelManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(CarModelAddDto carModelAddDto)
        {
            var carModel = _mapper.Map<CarModel>(carModelAddDto);
            await _unitOfWork.CarModelRepository.AddAsync(carModel);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"{carModel.Name} adlı model başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(int carModelId)
        {
            var result = await _unitOfWork.CarModelRepository.AnyAsync(c => c.ID == carModelId);
            if (result)
            {
                var carModel = await _unitOfWork.CarModelRepository.GetAsync(c => c.ID == carModelId);
                carModel.IsDeleted = true;
                await _unitOfWork.CarModelRepository.UpdateAsync(carModel);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{carModel.Name} adlı model başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz model bilgisi bulunamamaktadır.");
        }

        public async Task<IDataResult<CarModelDto>> Get(int carModelId)
        {
            var carModel = await _unitOfWork.CarModelRepository.GetAsync(b => b.ID == carModelId);
            if (carModel is not null)
            {
                return new DataResult<CarModelDto>(new CarModelDto { CarModel = carModel, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarModelDto>(new CarModelDto { CarModel = carModel, ResultStatus = ResultStatus.Error, Message = "İlgili model bulunamadı" },
                ResultStatus.Error);
        }

        public async Task<IDataResult<CarModelListDto>> GetAll()
        {
            var carModels = await _unitOfWork.CarModelRepository.GetAllAsync();
            if (carModels.Count > 0)
            {
                return new DataResult<CarModelListDto>(new CarModelListDto { CarModels = carModels, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarModelListDto>(new CarModelListDto
            {
                CarModels = carModels,
                ResultStatus = ResultStatus.Error,
                Message = "Model bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IDataResult<CarModelListDto>> GetAllByNonDeleted()
        {
            var carModels = await _unitOfWork.CarModelRepository.GetAllAsync(c=>c.IsDeleted == false, c=>c.Brand, c=>c.Cars);
            if (carModels.Count > 0)
            {
                return new DataResult<CarModelListDto>(new CarModelListDto { CarModels = carModels, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarModelListDto>(new CarModelListDto
            {
                CarModels = carModels,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş model bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IResult> HardDelete(int carModelId)
        {
            var result = await _unitOfWork.CarModelRepository.AnyAsync(b => b.ID == carModelId);
            if (result)
            {
                var carModel = await _unitOfWork.CarModelRepository.GetAsync(b => b.ID == carModelId);
                await _unitOfWork.CarModelRepository.RemoveAsync(carModel);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{carModel.Name} adlı model başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz marka bilgisi bulunamamaktadır.");
        }

        public async Task<IResult> Update(CarModelUpdateDto carModelUpdateDto)
        {
            var result = await _unitOfWork.CarModelRepository.AnyAsync(b => b.ID == carModelUpdateDto.ID);
            if (result)
            {
                var carModel = _mapper.Map<CarModel>(carModelUpdateDto);
                await _unitOfWork.CarModelRepository.UpdateAsync(carModel);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{carModel.Name} adlı model başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz model bilgisi bulunamamaktadır.");
        }

        public async Task<IDataResult<CarModelListDto>> GetAllByNonDeletedByBrandId(int brandId)
        {
            var carModels = await _unitOfWork.CarModelRepository.GetAllAsync(c => c.IsDeleted == false && c.BrandId == brandId);
            if (carModels.Count > 0)
            {
                return new DataResult<CarModelListDto>(new CarModelListDto { CarModels = carModels, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<CarModelListDto>(new CarModelListDto
            {
                CarModels = carModels,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş model bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IDataResult<CarModelDto>> AddWithReturn(CarModelAddDto carModelAddDto)
        {
            var carModel = _mapper.Map<CarModel>(carModelAddDto);
            var addedCarModel =  await _unitOfWork.CarModelRepository.AddWithReturn(carModel);
            addedCarModel.Brand = await _unitOfWork.BrandRepository.GetAsync(b=>b.ID == addedCarModel.BrandId);
            await _unitOfWork.SaveAsync();
            return new DataResult<CarModelDto>(new CarModelDto
            {
                CarModel = addedCarModel,
                ResultStatus = ResultStatus.Success,
                Message = $"{carModel.Name} adlı model başarıyla eklenmiştir."
            },ResultStatus.Success,message: $"{carModel.Name} adlı model başarıyla eklenmiştir.");
        }
    }
}
