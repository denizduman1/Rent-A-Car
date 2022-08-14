using System.Text.Json.Serialization;
using Entity.Concrete;
using Services.Extensions;
using WebUI.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(
opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSession();
builder.Services.LoadMyServices();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddIdentity<User, Role>(); //çok kritik
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Admin/User/UserLogin");
    opt.LogoutPath = new PathString("/Admin/User/UserLogout");
    opt.Cookie = new CookieBuilder
    {
        Name = "RentCarLoginUser",
        HttpOnly = true, // js den cookieleri göremesin
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest, // always olmalý
    };
    opt.SlidingExpiration = true; // kullanýcý giriþ yaptýktan sonra zaman tanýr(tekrar giriþ yapma süresi)
    opt.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    opt.AccessDeniedPath = new PathString("/Admin/User/AccessDenied"); //giriþ yapmýþ ama yetkisi yok
    
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStatusCodePages();
}

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

//authentica ve authorize
app.UseAuthentication(); // kimlik kontrol
app.UseAuthorization(); // yetki kontrol

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();
