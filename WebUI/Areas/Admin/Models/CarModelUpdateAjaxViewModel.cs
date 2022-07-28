using Entity.Concrete.DTOs;

namespace WebUI.Areas.Admin.Models
{
    public class CarModelUpdateAjaxViewModel
    {
        public CarModelUpdateDto? CarModelUpdateDto { get; set; }
        public string? CarModelUpdatePartial { get; set; }
        public CarModelDto? CarModelDto { get; set; }
    }
}
