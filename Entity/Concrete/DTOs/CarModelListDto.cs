using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class CarModelListDto : DtoGetBase
    {
        public IList<CarModel>? CarModels { get; set; }
    }
}
