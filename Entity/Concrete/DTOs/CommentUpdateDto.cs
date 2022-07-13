using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class CommentUpdateDto
    {
        [Required]
        public int ID { get; set; }
        [DisplayName("Yorum")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        public string? Description { get; set; }
        [DisplayName("Yıldız")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public short Star { get; set; }
    }
}
