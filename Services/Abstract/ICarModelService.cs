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
    public interface ICarModelService
    {
        public Task<IDataResult<CarModelDto>> Get(int carModelId);
        public Task<IDataResult<CarModelUpdateDto>> GetUpdateDto(int carModelId);
        public Task<IDataResult<CarModelListDto>> GetAll();
        public Task<IDataResult<CarModelListDto>> GetAllByNonDeleted();
        public Task<IDataResult<CarModelListDto>> GetAllByNonDeletedByBrandId(int brandId);
        public Task<IResult> Add(CarModelAddDto carModelAddDto);
        public Task<IDataResult<CarModelDto>> AddWithReturn(CarModelAddDto carModelAddDto);
        public Task<IResult> Update(CarModelUpdateDto carModelUpdateDto);
        public Task<IResult> Delete(int carModelId);
        public Task<IResult> HardDelete(int carModelId);
    }
}
