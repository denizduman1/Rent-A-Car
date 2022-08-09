using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Services.Abstract;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class TopBarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public TopBarViewComponent(UserManager<User> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var notifications = _notificationService.GetAllByNonDeleted();
            return View(
                        new TopBarModel
                        {
                            User = user,
                            Notification = notifications.Result.Notifications
                        }
                       );
        }
    }
}
