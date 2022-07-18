using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> List()
        {
            var result = await _carService.GetAllByNonDeleted();
            return View(result.Data);
        }
    }
}
