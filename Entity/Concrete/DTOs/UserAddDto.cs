using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        public string UserName { get; set; }
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(200, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(13, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")] // +905555555555 13 karakter olcak
        [MinLength(13, ErrorMessage = "{0} alanı {1} karakterden küçük olmamlıdır.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lütfen bir {0} seçiniz")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string? Image { get; set; }
    }
}
