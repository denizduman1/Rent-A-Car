using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public CarController(ICarService carService, ICarModelService carModelService, IBrandService brandService)
        {
            _carService = carService;
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> List()
        {
            var result = await _carService.GetAllByNonDeleted();
            return View(result.Data);
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

            return PartialView("_CarAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarAddDto carAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _carService.Add(carAddDto);
                return Json(result);
            }
            var errorMessage = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

            string errorResultMessage = "Ekleme sırasında hata ile karşılaşıldı.";

            foreach (var errMsg in errorMessage)
            {
                errorResultMessage += errMsg.ToString();
            }

            Result errorResult = new(ResultStatus.Error, errorResultMessage);

            return Json(errorResult);
        }

    }
}
