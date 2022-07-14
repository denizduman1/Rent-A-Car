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
    public class BrandManager : IBrandService
    {
        private IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public BrandManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(BrandAddDto brandAddDto)
        {
            var brand = _mapper.Map<Brand>(brandAddDto);
            await _unitOfWork.BrandRepository.AddAsync(brand);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"{brand.Name} adlı marka başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(int brandId)
        {
            var result = await _unitOfWork.BrandRepository.AnyAsync(b => b.ID == brandId);
            if (result)
            {
                var brand = await _unitOfWork.BrandRepository.GetAsync(b => b.ID == brandId);
                brand.IsDeleted = true;
                await _unitOfWork.BrandRepository.UpdateAsync(brand);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{brand.Name} markası başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz marka bilgisi bulunamamaktadır.");
        }

        public async Task<IDataResult<BrandDto>> Get(int brandId)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(b=>b.ID == brandId);
            if (brand is not null)
            {
                return new DataResult<BrandDto>(new BrandDto { Brand = brand, ResultStatus = ResultStatus.Success},ResultStatus.Success);
            }
            return new DataResult<BrandDto>(new BrandDto { Brand = brand, ResultStatus = ResultStatus.Error, Message = "İlgili marka bulunamadı" }, 
                ResultStatus.Error);
        }

        public async Task<IDataResult<BrandListDto>> GetAll()
        {
            var brands = await _unitOfWork.BrandRepository.GetAllAsync();
            if (brands.Count > 0)
            {
                return new DataResult<BrandListDto>(new BrandListDto { Brands = brands, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<BrandListDto>(new BrandListDto { Brands = brands, ResultStatus = ResultStatus.Error,
                Message = "Marka bulunamadı" }, ResultStatus.Error);
        }

        public async Task<IDataResult<BrandListDto>> GetAllByNonDeleted()
        {
            var brands = await _unitOfWork.BrandRepository.GetAllAsync(b=>b.IsDeleted == false);
            if (brands.Count > 0)
            {
                return new DataResult<BrandListDto>(new BrandListDto { Brands = brands, ResultStatus = ResultStatus.Success }, ResultStatus.Success);
            }
            return new DataResult<BrandListDto>(new BrandListDto
            {
                Brands = brands,
                ResultStatus = ResultStatus.Error,
                Message = "Silinmemiş marka bulunamadı"
            }, ResultStatus.Error);
        }

        public async Task<IResult> HardDelete(int brandId)
        {
            var result = await _unitOfWork.BrandRepository.AnyAsync(b => b.ID == brandId);
            if (result)
            {
                var brand = await _unitOfWork.BrandRepository.GetAsync(b => b.ID == brandId);
                await _unitOfWork.BrandRepository.RemoveAsync(brand);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{brand.Name} markası başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success, $"Silmek istediğiniz marka bilgisi bulunamamaktadır.");
        }

        public async Task<IResult> Update(BrandUpdateDto brandUpdateDto)
        {
            var result = await _unitOfWork.BrandRepository.AnyAsync(b => b.ID == brandUpdateDto.ID);
            if (result)
            {
                var brand = _mapper.Map<Brand>(brandUpdateDto);
                await _unitOfWork.BrandRepository.UpdateAsync(brand);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"{brand.Name} adlı marka başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Success, message: $"Güncellemek istediğiniz marka bulunamamaktadır.");
        }
    }
}
