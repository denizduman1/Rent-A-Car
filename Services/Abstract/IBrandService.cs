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
    public interface IBrandService
    {
        public Task<IDataResult<Brand>> Get(int brandId);
        public Task<IDataResult<IList<Brand>>> GetAll();
        public Task<IDataResult<IList<Brand>>> GetAllByNonDeleted();
        public Task<IResult> Add(BrandAddDto brandAddDto);
        public Task<IResult> Update(BrandUpdateDto brandUpdateDto);
        public Task<IResult> Delete(int brandId);
        public Task<IResult> HardDelete(int brandId);
    }
}
