using Entity.ComplexTypes;
using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Car : EntityBase, IEntity
    {
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public VehicleType VehicleType { get; set; }
        public int DailyPrice { get; set; }
        public DateTime ModelYear { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
