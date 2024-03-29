﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISepetService
    {
        void SepetEkle(Car car);
        void SepetCikar(int car);
        IList<Car> SepetList();
        void SepetBosalt();
    }
}
