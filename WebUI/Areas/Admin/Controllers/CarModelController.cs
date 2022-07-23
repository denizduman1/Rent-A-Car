using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService carModelService, IBrandService brandService)
        {
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> List()
        {
            var carModels = await _carModelService.GetAllByNonDeleted();
            return View(carModels.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var brandResult = await _brandService.GetAllByNonDeleted();
            var brandSelectList = brandResult?.Data?.Brands?.Select(b => new SelectListItem()
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();

            ViewBag.PageState = new DashboardModel
            {
                SelectListItemForBrands = brandSelectList
            };
            return PartialView("_CarModelAddPartial");
        }
    }
}
