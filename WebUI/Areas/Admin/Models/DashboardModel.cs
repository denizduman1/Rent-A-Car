using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models
{
    public class DashboardModel
    {
        public BrandListDto? BrandListDto { get; set; }
        public CarListDto? CarListDto { get; set; }
        public CarModelListDto? CarModelListDto { get; set; }
        public List<SelectListItem>? SelectListItemForBrands { get; set; }
    }
}
