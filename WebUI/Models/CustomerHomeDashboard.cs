using Entity.Concrete;
using Entity.Concrete.DTOs;

namespace WebUI.Models
{
    public class CustomerHomeDashboard
    {
        public CarListDto Cars { get; set; }
        public CommentListDto Comments { get; set; }
        public IList<Brand> Brands { get; set; }
    }
}
