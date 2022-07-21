using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models
{
    public class DashboardModel
    {
        public BrandListDto? BrandListDto { get; set; }
        public CarListDto? CarListDto { get; set; }
        public CarModelListDto? CarModelListDto { get; set; }
        public List<SelectListItem>? SelectListItemForColors { get; set; }
        public List<SelectListItem>? SelectListItemForBrands { get; set; }
        public List<SelectListItem>? SelectListItemForTransmissionType { get; set; }
        public List<SelectListItem>? SelectListItemForFuelType { get; set; }
        public List<SelectListItem>? SelectListItemForVehicleType { get; set; }
    }
}
