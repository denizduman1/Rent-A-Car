using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class CarListDto : DtoGetBase
    {
        public IList<Car>? Cars { get; set; }
    }
}
