using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class User : IdentityUser<int>
    {
        public string? Image { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
