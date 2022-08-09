using Entity.Concrete;

namespace WebUI.Areas.Admin.Models
{
    public class TopBarModel
    {
        public User User { get; set; }
        public IList<Notification> Notification { get; set; }
    }
}
