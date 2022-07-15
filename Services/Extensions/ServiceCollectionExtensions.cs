using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.AutoMapper.Profiles;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<RentCarContext>();
            serviceCollection.AddScoped<IUnitOfWork,EfUnitOfWork>();
            serviceCollection.AddAutoMapper(typeof(BrandProfile), typeof(CarModelProfile), typeof(CommentProfile), typeof(ColorProfile), typeof(CarProfile));
            serviceCollection.AddScoped<IBrandService, BrandManager>();
            serviceCollection.AddScoped<ICarService, CarManager>();
            serviceCollection.AddScoped<ICarModelService, CarModelManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddScoped<IColorService, ColorManager>();
            // session sepet işlemleri için sonra eklenecek.
            // servicCollection.AddHttpContextAccessor();
            return serviceCollection;
        }
    }
}
