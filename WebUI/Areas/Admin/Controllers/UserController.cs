using AutoMapper;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Utilities.Extensions;
using Shared.Utilities.Results.ComplexTypes;
using System.Text.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper)
        {
            _userManager = userManager;
            _env = env;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                userAddDto.Image = await ImageUpload(userAddDto);
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user,userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                             ResultStatus = ResultStatus.Success,
                             Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı başarıyla eklenmiştir.",
                             User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    string identityError = "";
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                        identityError += error.Description;
                    }
                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto),
                        UserAddDto = userAddDto,
                        UserDto = new UserDto
                        {
                            Message = identityError
                        }
                    });
                    return Json(userAddAjaxErrorModel);
                }
            }
            var userAddAjaxStateErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto),
                UserAddDto = userAddDto
            });
            return Json(userAddAjaxStateErrorModel);
        }

        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            string wwwroot = _env.WebRootPath;

            //denizduman
            // string fileName = Path.GetFileNameWithoutExtension(userAddDto.PictureFile.FileName);

            // png||jpg
            string fileExtension = Path.GetExtension(userAddDto.PictureFile.FileName);

            DateTime dateTime = DateTime.Now;

            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/Admin/dz-img/user-img",fileName);
            await using (var stream = new FileStream(path,FileMode.Create))
            {
                await userAddDto.PictureFile.CopyToAsync(stream);
            }
            return fileName; 
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedUser = JsonSerializer.Serialize(new UserDto
                {
                    Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı başarıyla silinmiştir",
                    User = user,
                    ResultStatus = ResultStatus.Success
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMesages = String.Empty;
                foreach (var error in result.Errors)
                {
                   errorMesages +=  $"*{error.Description}\n";
                }
                var deletedErrorUser = JsonSerializer.Serialize(new UserDto
                {
                    Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı silinirken bazı hatalar oluştu. \n{errorMesages}",
                    User = user,
                    ResultStatus = ResultStatus.Error
                });
                return Json(deletedErrorUser);
            }
        }
    
    }
}
