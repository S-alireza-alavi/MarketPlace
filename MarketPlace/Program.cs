//using App.Domain.Core.Entities;
//using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.AppService;
using App.Domain.AppService.Admins.Commands;
using App.Domain.AppService.Admins.Queries;
using App.Domain.AppService.Customers.Queries;
using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using App.Infrastructures.Data.Repositories;
using MarketPlace.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.RequireUniqueEmail = false;

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<AppDbContext>();

            //todo: remember to change the location of these IOC container injects
            // Add services to the container.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUsersAppService, UsersAppService>();
            builder.Services.AddScoped<IStoreRepository, StoreRepository>();
            builder.Services.AddScoped<IStoresServiceAppService, StoresServiceAppService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductsServiceAppService, ProductsServiceAppService>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandsService, BrandsService>();
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IModelService, ModelService>();
            builder.Services.AddScoped<IStoreAppService, StoreAppService>();
            builder.Services.AddScoped<ICommissionRepository, CommissionRepository>();
            builder.Services.AddScoped<ICommissionsServiceAppService, CommissionsServiceAppService>();
            builder.Services.AddScoped<IConfirmSellersProductServiceAppService, ConfirmSellersProductServiceAppService>();
            builder.Services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            builder.Services.AddScoped<IStoreCommentRepository, StoreCommentRepository>();
            builder.Services.AddScoped<IConfirmCustomersCommentServiceAppService, ConfirmCustomersCommentServiceAppService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
            });

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

            app.UseAuthorization();


            app.MapAreaControllerRoute(
              name: "areas",
              areaName: "Admin",
              pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}