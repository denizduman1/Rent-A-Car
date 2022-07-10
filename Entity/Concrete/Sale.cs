using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Sale : EntityBase, IEntity
    {
        public DateTime ReservationDate { get; set; }
        public DateTime EODDate { get; set; }
        public bool IsCancelled { get; set; } = false;
        public int PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
