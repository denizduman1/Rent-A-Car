using Entity.Concrete;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISaleService
    {
        public Task<IDataResult<Sale>> Get(int saleId);
        public Task<IDataResult<IList<Sale>>> GetAll();
        public Task<IDataResult<IList<Sale>>> GetAllByNonDeleted();
        public Task<IResult> Add(Sale sale);
        public Task<IResult> Update(Sale sale);
        public Task<IResult> Delete(int saleId);
        public Task<IResult> HardDelete(int saleId);
    }
}
