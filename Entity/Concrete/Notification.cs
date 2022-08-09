using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Notification : EntityBase,IEntity
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
