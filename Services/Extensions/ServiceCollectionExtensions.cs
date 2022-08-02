using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
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
            serviceCollection.AddScoped<IPaymentService, PaymentManager>();
            serviceCollection.AddIdentityCore<User>(opt =>
            {   //üye kaydolma ayarları
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;

                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RentCarContext>();
            // session sepet işlemleri için sonra eklenecek.
            // servicCollection.AddHttpContextAccessor();
            return serviceCollection;
        }
    }
}
