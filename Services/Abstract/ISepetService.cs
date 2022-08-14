using Entity.Concrete;
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
        void SepetCikar(Car car);
        IList<Car> SepetList();
    }
}
