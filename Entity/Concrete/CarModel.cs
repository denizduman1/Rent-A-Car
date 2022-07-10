using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class CarModel : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public Brand? Brand { get; set; }
        public int BrandId { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
