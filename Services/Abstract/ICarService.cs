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
    public interface ICarService
    {
        public Task<IDataResult<CarDto>> Get(int carId);
        public Task<IDataResult<CarListDto>> GetAll();
        public Task<IDataResult<CarListDto>> GetAllByNonDeleted();
        public Task<IDataResult<CarListDto>> GetAllByNonDeletedAndMostStar();
        public Task<IResult> Add(CarAddDto carAddDto);
        public Task<IResult> Update(CarUpdateDto carUpdateDto);
        public Task<IResult> Delete(int carId);
        public Task<IResult> HardDelete(int carId);
    }
}
