using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class PaymentUpdateDto
    {
        public int ID { get; set; }
        public bool IsCancelled { get; set; }
    }
}
