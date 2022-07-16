using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Utilities.Results.ComplexTypes;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
