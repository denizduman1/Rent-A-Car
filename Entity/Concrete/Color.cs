using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Color : EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
