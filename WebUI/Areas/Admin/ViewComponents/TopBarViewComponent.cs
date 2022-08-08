using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class TopBarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public TopBarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new TopBarModel
            {
                User = user
            });
        }
    }
}
