using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Payment : EntityBase, IEntity
    {
        public short DayCount { get; set; }
        public int TotalPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }
    }
}
