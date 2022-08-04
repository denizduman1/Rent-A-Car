using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> List()
        {
            var brands = await _brandService.GetAllByNonDeleted();
            return View(brands.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_BrandAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandAddDto brandAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _brandService.Add(brandAddDto);
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

        [HttpPost]
        public async Task<JsonResult> Remove(int brandId)
        {
            var result = await _brandService.Delete(brandId);       
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int brandId)
        {
            var result = await _brandService.GetUpdateDto(brandId);
            return PartialView("_BrandUpdatePartial",result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BrandUpdateDto brandUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _brandService.Update(brandUpdateDto);
                return Json(result);
            }
            var errorMessage = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

            string errorResultMessage = "Güncelleme sırasında hata ile karşılaşıldı.";

            foreach (var errMsg in errorMessage)
            {
                errorResultMessage += errMsg.ToString();
            }

            Result errorResult = new(ResultStatus.Error, errorResultMessage);

            return Json(errorResult);
        }
    }
}
