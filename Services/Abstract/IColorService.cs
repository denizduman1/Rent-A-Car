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
    public interface IColorService
    {
        public Task<IDataResult<ColorDto>> Get(int colorId);
        public Task<IDataResult<ColorListDto>> GetAll();
        public Task<IDataResult<ColorListDto>> GetAllByNonDeleted();
        public Task<IResult> Add(ColorAddDto colorAddDto);
        public Task<IResult> Update(ColorUpdateDto colorUpdateDto);
        public Task<IResult> Delete(int colorId);
        public Task<IResult> HardDelete(int colorId);
    }
}
