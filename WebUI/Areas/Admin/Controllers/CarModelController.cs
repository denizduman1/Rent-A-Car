using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Services.Abstract;
using Shared.Utilities.Extensions;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
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
            await SelectListForBrands();
            return PartialView("_CarModelAddPartial");
        }

        private async Task SelectListForBrands()
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
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModelAddDto carModelAddDto)
        {
            await SelectListForBrands();

            if (ModelState.IsValid)
            {
                var result = await _carModelService.AddWithReturn(carModelAddDto);
                
                if (result.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                {
                    var carModelAddAjaxModel = JsonConvert.SerializeObject(new CarModelAddAjaxViewModel
                    {
                        CarModelDto = result.Data,
                        CarModelAddPartial = await this.RenderViewToStringAsync("_CarModelAddPartial", carModelAddDto)
                    }, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.None
                    });
                    return Json(carModelAddAjaxModel);
                }
            }

            var carModelAddAjaxErrorModel = JsonConvert.SerializeObject(new CarModelAddAjaxViewModel
            {
                CarModelAddPartial = await this.RenderViewToStringAsync("_CarModelAddPartial",carModelAddDto)              
            }, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None
            });
            return Json(carModelAddAjaxErrorModel);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int carModelId)
        {
            if (carModelId != 0)
            {
                var result = await _carModelService.Delete(carModelId);
                if (result.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                {
                    return Json(new { message = result.Message, resultStatus = true });
                }
                else
                {
                    return Json(new { message = result.Message });
                }
            }
            return Json(new { message = "id 0 olamaz" });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int carModelId)
        {
            await SelectListForBrands();
            var result = await _carModelService.GetUpdateDto(carModelId);
            return PartialView("_CarModelUpdatePartial",result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarModelUpdateDto carModelUpdateDto)
        {
            await SelectListForBrands();

            if (ModelState.IsValid)
            {
                var result = await _carModelService.UpdateWithReturn(carModelUpdateDto);

                if (result.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                {
                    var carModelUpdateAjaxModel = JsonConvert.SerializeObject(new CarModelUpdateAjaxViewModel
                    {
                        CarModelDto = result.Data,
                        CarModelUpdatePartial = await this.RenderViewToStringAsync("_CarModelUpdatePartial", carModelUpdateDto)
                    }, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.None
                    });
                    return Json(carModelUpdateAjaxModel);
                }
            }

            var carModelUpdateAjaxErrorModel = JsonConvert.SerializeObject(new CarModelUpdateAjaxViewModel
            {
                CarModelUpdatePartial = await this.RenderViewToStringAsync("_CarModelUpdatePartial", carModelUpdateDto)
            }, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None
            });
            return Json(carModelUpdateAjaxErrorModel);
        }
    }
}
