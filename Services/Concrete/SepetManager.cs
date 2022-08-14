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
        public void SepetCikar(int Id)
        {
            var str = _httpContextAccessor.HttpContext.Session.GetString("sepet");
            var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str, new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.None
            });
            gelenListe.RemoveAll(c => c.ID == Id);
            var convertToStr = JsonConvert.SerializeObject(gelenListe, new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.None
            });
            _httpContextAccessor.HttpContext.Session.SetString("sepet", convertToStr);
        }

        public void SepetEkle(Car car)
        {
            var str = _httpContextAccessor.HttpContext.Session.GetString("sepet");
            if (!string.IsNullOrWhiteSpace(str))
            {
                var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str, new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.None
            });
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
                var gelenListe = JsonConvert.DeserializeObject<List<Car>>(str, 
                    new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                        Formatting = Newtonsoft.Json.Formatting.None });
                return gelenListe;
            }
            return new List<Car>();
        }
    }
}
