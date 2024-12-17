using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IoC Container:
string connectionString = builder.Configuration.GetConnectionString("Db"); // TODO: DB Name Change
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

// Way 1:
//builder.Services.AddScoped<ICategoryService, CategoryService>();
// Way 2:
builder.Services.AddScoped<IService<Category, CategoryModel>, CategoryService>();

// Way 1:
//builder.Services.AddScoped<IProductService, ProductService>();
// Way 2:
builder.Services.AddScoped<IService<Product, ProductModel>, ProductService>();

builder.Services.AddScoped<IService<Store, StoreModel>, StoreService>();

builder.Services.AddScoped<IService<User, UserModel>, UserService>();

// Authentication:
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/Login";
        options.AccessDeniedPath = "/Users/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
    });

// AppSettings:
var section = builder.Configuration.GetSection(nameof(AppSettings));
section.Bind(new AppSettings());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication:
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
