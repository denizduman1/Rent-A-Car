using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> List()
        {
            var payments = await _paymentService.GetAllByNonDeleted();
            return View(payments.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Pay(int paymentId)
        {
            var payment = await _paymentService.Pay(paymentId);
            return Json(payment);
        }

    }
}
