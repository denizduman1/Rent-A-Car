﻿using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class BrandDto : DtoGetBase
    {
        public Brand? Brand { get; set; }
    }
}
