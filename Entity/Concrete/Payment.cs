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
        public short DayCount { get; set; } // kaç gün kiralamak istediği
        public int TotalPrice { get; set; } // total ücret
        public bool IsPaid { get; set; } = false; // ödendi mi
        public bool IsCancelled { get; set; } = false; // ödemeyi geciktirdi mi
        public DateTime ReservationDate { get; set; } = DateTime.Now; // order date
        public DateTime EODDate { get; set; } = DateTime.Now.AddHours(6); // order date + 6 saat
        public int CarId { get; set; } // araç
        public Car? Car { get; set; }
        public int UserId { get; set; } // kullanıcı
        public User? User { get; set; }
    }
}
