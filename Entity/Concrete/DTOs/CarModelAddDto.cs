using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class CarModelAddDto
    {
        [DisplayName("Model")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(80, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        public string? Name { get; set; }
        public Brand? Brand { get; set; }
        [DisplayName("Marka")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int BrandId { get; set; }
    }
}
