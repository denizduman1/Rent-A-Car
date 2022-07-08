using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Description { get; set; }
        public short Star { get; set; }
        public int LikeCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
