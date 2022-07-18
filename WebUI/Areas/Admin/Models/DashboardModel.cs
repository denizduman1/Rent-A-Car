using Entity.Concrete.DTOs;

namespace WebUI.Areas.Admin.Models
{
    public class DashboardModel
    {
        public BrandListDto? BrandListDto { get; set; }
        public CarListDto? CarListDto { get; set; }
        public CarModelListDto? CarModelListDto { get; set; }
    }
}
