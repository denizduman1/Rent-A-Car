using Entity.Concrete;
using Entity.Concrete.DTOs;

namespace WebUI.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto? UserAddDto { get; set; }
        public string? UserAddPartial { get; set; }
        public UserDto? UserDto { get; set; } 
    }
}
