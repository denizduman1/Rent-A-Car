using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public NavbarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new NavbarModel
            {
                User = user
            });
        }
    }
}
