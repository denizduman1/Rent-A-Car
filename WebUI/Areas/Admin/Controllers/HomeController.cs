using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICarService _carService; 
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public HomeController(ICarService carService, ICarModelService carModelService, IBrandService brandService)
        {
            _carService = carService;
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllByNonDeleted();
            var carModels = await _carModelService.GetAllByNonDeleted();
            var brands = await _brandService.GetAllByNonDeleted();
            ViewBag.PageState = new DashboardModel()
            {
                BrandListDto = brands.Data,
                CarListDto = cars.Data,
                CarModelListDto = carModels.Data
            };
            return View();
        }

    }
}
