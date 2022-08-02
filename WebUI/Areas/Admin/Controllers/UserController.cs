using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Utilities.Extensions;
using Shared.Utilities.Results.ComplexTypes;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> List()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }

        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            string wwwroot = _env.WebRootPath;

            //denizduman
            // string fileName = Path.GetFileNameWithoutExtension(userAddDto.Picture.FileName);

            // png||jpg
            string fileExtension = Path.GetExtension(userAddDto.Picture.FileName);

            DateTime dateTime = DateTime.Now;

            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/Admin/dz-img/user-img",fileName);
            await using (var stream = new FileStream(path,FileMode.Create))
            {
                await userAddDto.Picture.CopyToAsync(stream);
            }
            return fileName; 
        }
    }
}
