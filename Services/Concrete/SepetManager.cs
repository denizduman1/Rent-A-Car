using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class SepetManager : ISepetService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SepetManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SepetCikar(Car car)
        {
            var str = _httpContextAccessor.HttpContext.Session.GetString("sepet");
            var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str);
            gelenListe.Remove(car);
            var convertToStr = JsonConvert.SerializeObject(gelenListe);
            _httpContextAccessor.HttpContext.Session.SetString("sepet", convertToStr);
        }

        public void SepetEkle(Car car)
        {
            var str = _httpContextAccessor.HttpContext.Session.GetString("sepet");
            if (!string.IsNullOrWhiteSpace(str))
            {
                var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str);
                gelenListe.Add(car);
                var convertToStr = JsonConvert.SerializeObject(gelenListe, new JsonSerializerSettings{
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    Formatting = Newtonsoft.Json.Formatting.None
                });
                _httpContextAccessor.HttpContext.Session.SetString("sepet", convertToStr);
            }
            else
            {
                var yeniListe = new List<Car>();
                yeniListe.Add(car);
                var convertToStr = JsonConvert.SerializeObject(yeniListe, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    Formatting = Newtonsoft.Json.Formatting.None
                }); _httpContextAccessor.HttpContext.Session.SetString("sepet", convertToStr);
            }
        }

        public IList<Car> SepetList()
        {
            var str = _httpContextAccessor.HttpContext.Session.GetString("sepet");

            if (!string.IsNullOrWhiteSpace(str))
            {
                var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str);
                return gelenListe;
            }
            return new List<Car>();
        }
    }
}
