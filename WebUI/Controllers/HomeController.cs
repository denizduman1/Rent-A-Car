using AutoMapper;
using Entity.Concrete;
using Entity.Concrete.DTOs;
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
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper,UserManager<User> userManager, ICarService carService, IBrandService brandService, ICommentService commentService, ISepetService sepetService)
        {
            _carService = carService;
            _commentService = commentService;
            _brandService = brandService;
            _sepetService = sepetService;
            _userManager = userManager;
            _mapper = mapper;
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

        public async Task<IActionResult> Cars()
        {
            var cars = await _carService.GetAllByNonDeleted();
            var brands = await _brandService.GetAllByNonDeleted();
            ViewBag.PageState = brands.Data.Brands;
            return View(cars.Data.Cars);
        }

        public async Task<IActionResult> BasketList()
        {
            var car = _sepetService.SepetList();
            ViewBag.PageState = car;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EkleSepet(int id)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            if (user == null)
            {
                return Json(new { isSuccess = false, msg = "Kullanıcı Girişi Yapmadan ürün ekleyemezsiniz." });
            }

            var anySepet = _sepetService.SepetList().Any();

            if (anySepet)
            {
                return Json(new { isSuccess = false, msg = "Sepetinizde ürün varken başka ürün ekleyemezsiniz." });
            }

            var car = await _carService.Get(id);
            if (car != null)
            {
                _sepetService.SepetEkle(car.Data.Car);
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }

        [HttpPost]
        public async Task<IActionResult> CikarSepet(int id)
        {
            _sepetService.SepetCikar(id);
            return Json(new { isSuccess = true });
        }
    
        public async Task<IActionResult> Comments()
        {
            var result = await _commentService.GetAllByNonDeleted();
            var comments = result.Data.Comments;

            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            ViewBag.PageState = user;

            return View(comments);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string msg)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            Comment comment = new Comment
            {
                Description = msg,
                UserId = user.Id,
                Star = 5,
                IsDeleted = false,
                LikeCount = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _commentService.AddNotDto(comment);

            return Json(new { isSuccess = true });
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentLike(int Id)
        {
            var result = await _commentService.Get(Id);

            var comment = result.Data.Comment;

            comment.LikeCount++;

            await _commentService.UpdateNotDto(comment);

            return Json(new { isSuccess = true });
        }
    }
}
