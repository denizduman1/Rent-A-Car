using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class CarAddDto
    {
        [DisplayName("Vites Tipi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int TransmissionType { get; set; }
        [DisplayName("Yakıt Tipi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int FuelType { get; set; }
        [DisplayName("Kasa Tipi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int VehicleType { get; set; }
        [DisplayName("Günlük Ücret")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int DailyPrice { get; set; }
        [DisplayName("Çıkış Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int ModelYear { get; set; }
        [DisplayName("Fotoğraf")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public string? Image { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        public string? Description { get; set; }
        [DisplayName("Toplam Adet")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int TotalCount { get; set; }
        [DisplayName("Model")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int CarModelId { get; set; }
        public CarModel? CarModel { get; set; }
        [DisplayName("Renk")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
