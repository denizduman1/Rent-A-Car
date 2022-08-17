using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class PaymentAddDto
    {
        public int DayCount { get; set; }
        public int TotalPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime EODDate { get; set; }
        public bool IsCancelled { get; set; } = false;
        public DateTime ReservationDate { get; set; } 
    }
}
