﻿using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string? Message { get; set; }
    }
}
