using AutoMapper;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICarService _carService; 
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper,ICarService carService, ICarModelService carModelService, IBrandService brandService, INotificationService notificationService)
        {
            _mapper = mapper;
            _carService = carService;
            _carModelService = carModelService;
            _brandService = brandService;
            _notificationService = notificationService;
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

        [HttpPost]
        public async Task<IActionResult> UpdateRead()
        {
            var result = await _notificationService.GetAllByNonDeleted();
            if (result.Notifications != null)
            {
                if (result.Notifications.Count > 0)
                {
                    foreach (var item in result.Notifications)
                    {
                        item.IsRead = true;
                        var notifactionUpdateDto = _mapper.Map<NotificationUpdateDto>(item);
                        await _notificationService.Update(notifactionUpdateDto);
                    }
                }
            }
            return Json(new {IsSuccess = true});
        }

    }
}
