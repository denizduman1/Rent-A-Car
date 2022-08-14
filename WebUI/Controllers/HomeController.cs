using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Text.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICommentService _commentService;
        private readonly IBrandService _brandService;
        private readonly ISepetService _sepetService;

        public HomeController(ICarService carService, IBrandService brandService, ICommentService commentService, ISepetService sepetService)
        {
            _carService = carService;
            _commentService = commentService;
            _brandService = brandService;
            _sepetService = sepetService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllByNonDeletedAndMostStar();
            var comments = await _commentService.GetAllByNonDeleted();
            var brands = await _brandService.GetAllByNonDeleted();

            var customerHomeDashboard = new CustomerHomeDashboard
            {
                Cars = cars.Data,
                Comments = comments.Data,
                Brands = brands.Data.Brands
            };
            return View(customerHomeDashboard);
        }

        public async Task<IActionResult> BasketList()
        {
            var car = _sepetService.SepetList();
            ViewBag.PageState = car;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EkleSepet(string id)
        {
            var car = await _carService.Get(Convert.ToInt32(id));
            if (car!=null)
            {
                _sepetService.SepetEkle(car.Data.Car);
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }

    }
}
