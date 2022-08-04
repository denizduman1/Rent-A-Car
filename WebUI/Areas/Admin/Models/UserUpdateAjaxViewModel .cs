using Entity.Concrete;
using Entity.Concrete.DTOs;

namespace WebUI.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto? UserUpdateDto { get; set; }
        public string? UserUpdatePartial { get; set; }
        public UserDto? UserDto { get; set; } 
    }
}
