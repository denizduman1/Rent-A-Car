using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        public async Task<IActionResult> List()
        {
            var carModels = await _carModelService.GetAllByNonDeleted();
            return View(carModels.Data);
        }
    }
}
