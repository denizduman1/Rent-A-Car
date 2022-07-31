using AutoMapper;
using Entity.ComplexTypes;
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
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, ICarModelService carModelService, IBrandService brandService, IColorService colorService
            ,IMapper mapper)
        {
            _carService = carService;
            _carModelService = carModelService;
            _brandService = brandService;
            _colorService = colorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var result = await _carService.GetAllByNonDeleted();
            return View(result.Data);
        }

        [HttpGet]
        public async Task<JsonResult> GetCarModelsByBrand(int brandId)
        {
            var result = await _carModelService.GetAllByNonDeletedByBrandId(brandId);
            if (result?.Data?.CarModels.Count() > 0)
            {
                return Json(result?.Data?.CarModels);
            }
            return Json(new { message = "Seçtiğiniz markaya ait model yok", isError = true });
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await SelectListState();

            return PartialView("_CarAddPartial");
        }

        private async Task SelectListState()
        {
            var brandResult = await _brandService.GetAllByNonDeleted();
            var brandSelectList = brandResult?.Data?.Brands?.Select(b => new SelectListItem()
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();

            var colorResult = await _colorService.GetAllByNonDeleted();
            var colorSelectList = colorResult?.Data?.Colors?.Select(b => new SelectListItem()
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();

            var transmissionType = from TransmissionType t in Enum.GetValues(typeof(TransmissionType))
                                   select new { Value = (int)t, Text = t.ToString() };

            var transmissionTypeSelectList = transmissionType.Select(t => new SelectListItem()
            {
                Value = t.Value.ToString(),
                Text = t.Text
            }).ToList();

            var fuelType = from FuelType f in Enum.GetValues(typeof(FuelType))
                           select new { Value = (int)f, Text = f.ToString() };

            var fuelTypeSelectList = fuelType.Select(f => new SelectListItem()
            {
                Value = f.Value.ToString(),
                Text = f.Text
            }).ToList();

            var vehicleType = from VehicleType v in Enum.GetValues(typeof(VehicleType))
                              select new { Value = (int)v, Text = v.ToString() };

            var vehicleTypeSelectList = vehicleType.Select(v => new SelectListItem()
            {
                Value = v.Value.ToString(),
                Text = v.Text
            }).ToList();           

            ViewBag.PageState = new DashboardModel
            {
                SelectListItemForBrands = brandSelectList,
                SelectListItemForColors = colorSelectList,
                SelectListItemForTransmissionType = transmissionTypeSelectList,
                SelectListItemForFuelType = fuelTypeSelectList,
                SelectListItemForVehicleType = vehicleTypeSelectList
            };
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

        [HttpPost]
        public async Task<IActionResult> Remove(int carId)
        {
            if (carId != 0)
            {
                var result = await _carService.Delete(carId);
                if (result.ResultStatus == ResultStatus.Success)
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
        public async Task<IActionResult> Update(int carId)
        {
            await SelectListState();
            var result = await _carService.Get(carId);


            var carModelResult = await _carModelService.GetAllByNonDeletedByBrandId(result.Data.Car.CarModel.BrandId);
            var carModelSelectList = carModelResult?.Data?.CarModels?.Select(b => new SelectListItem()
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();

            ViewBag.CarUpdate = carModelSelectList;

            var carUpdateDto = _mapper.Map<CarUpdateDto>(result.Data.Car);
            return PartialView("_CarUpdatePartial", carUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarUpdateDto carUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _carService.Update(carUpdateDto);
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
