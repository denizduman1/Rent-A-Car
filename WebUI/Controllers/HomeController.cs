using AutoMapper;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;

        public HomeController(IMapper mapper, INotificationService notificationService, IPaymentService paymentService, UserManager<User> userManager, ICarService carService, IBrandService brandService, ICommentService commentService, ISepetService sepetService)
        {
            _notificationService = notificationService;
            _carService = carService;
            _commentService = commentService;
            _brandService = brandService;
            _sepetService = sepetService;
            _userManager = userManager;
            _paymentService = paymentService;
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

        [HttpPost]
        public async Task<IActionResult> Payment(int totalPrice, int carId, int dailyCount)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var resCar = await _carService.Get(carId);
            var car = resCar.Data.Car;

            var payment = new PaymentAddDto
            {
                CarId = carId,
                DayCount = dailyCount,
                IsCancelled = false,
                EODDate = DateTime.Now.AddHours(6),
                IsPaid = false,
                ReservationDate = DateTime.Now,
                UserId = user.Id,
                TotalPrice = totalPrice
            };

            var res = await _paymentService.Add(payment);

            car.CurrentCount -= 1;

            await _carService.UpdateNotDto(car);

            _sepetService.SepetBosalt();

            var notificationAddDto = new NotificationAddDto
            {
                Message = $"{user.UserName} adlı kişi {car.CarModel.Brand.Name} {car.CarModel.Name} model aracı sipariş etmiştir."
            };

            await _notificationService.Add(notificationAddDto);

            return Json(new { isSuccess = true, msg = res.Message });
        }

        [HttpPost]
        public async Task<IActionResult> CarsbyBrandsId(int[] brandIds)
        {
            var res = await _carService.GetAllByNonDeleted();
            var cars = res.Data.Cars;
            if (brandIds.Count() > 0)
            {
                var carsFilter = res.Data.Cars.Where(c => brandIds.Contains(c.CarModel.Brand.ID)).ToList();
                return Json(JsonConvert.SerializeObject(new { carsData = carsFilter }, new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            return Json(JsonConvert.SerializeObject(new { carsData = cars }, new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
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

            var resPayment = await _paymentService.GetAllByNonDeleted();
            bool varMiPayment = resPayment.Data.Payments.Where(p => p.IsPaid == false && p.IsCancelled == false && p.UserId == user.Id).Any();

            if (varMiPayment)
            {
                return Json(new
                {
                    isSuccess = false,
                    msg = "Daha önce bir araç sipariş etmişsiniz onun süresi dolmadan yeni bir aracı" +
                    "sepetinize ekleyemessiniz"
                });
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
