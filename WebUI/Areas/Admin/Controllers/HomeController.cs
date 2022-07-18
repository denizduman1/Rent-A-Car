using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
