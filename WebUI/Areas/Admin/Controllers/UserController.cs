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
                userAddDto.Image = await ImageUpload(userAddDto.UserName, userAddDto.PictureFile);
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

        public async Task<string> ImageUpload(string userName, IFormFile pictureFile)
        {
            string wwwroot = _env.WebRootPath;

            //denizduman
            // string fileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);

            // png||jpg
            string fileExtension = Path.GetExtension(pictureFile.FileName);

            DateTime dateTime = DateTime.Now;

            string fileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/Admin/dz-img/user-img",fileName);
            await using (var stream = new FileStream(path,FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            return fileName; 
        }
        
        public bool ImageDelete(string imageName)
        {
            string wwwroot = _env.WebRootPath;
            var fileToDelete = Path.Combine($"{wwwroot}/Admin/dz-img/user-img", imageName);
            if (System.IO.File.Exists(fileToDelete))
            {
                System.IO.File.Delete(fileToDelete);
                return true;
            }
            return false;
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

        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.Id == userId); //satır bulamazsa null döner birden fazla dönerse ilkini döner
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
            return PartialView("_UserUpdatePartial", userUpdateDto);
        }
       
        [HttpPost]    
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            bool isNewImageUploaded = false;
            var oldUser = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            var oldUserImage = oldUser.Image;
            userUpdateDto.Image = oldUserImage; //resmi tut

            if (ModelState.IsValid)
            {                
                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Image = await ImageUpload(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    isNewImageUploaded = true;
                }
                var updatedUser = _mapper.Map<UserUpdateDto,User>(userUpdateDto,oldUser);
                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewImageUploaded == true)
                    {
                        ImageDelete(oldUserImage);
                    }
                    var userUpdateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            User = updatedUser, 
                            Message = $"{updatedUser.UserName} adlı kullanıcı başarıyla güncellenmiştir"
                        },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial",userUpdateDto)
                    });
                    return Json(userUpdateViewModel);
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("",err.Description);
                    }
                    var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserUpdateDto = userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdateErrorViewModel);
                }
            }
            else
            {
                var userUpdateErrorModelStateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                });
                return Json(userUpdateErrorModelStateViewModel);
            }
        }


        [HttpGet]
        public IActionResult UserLogin()
        {
            return View("UserLogin");
        }
    }
}
