//using App.Domain.Core.Entities;
//using App.Infrastructures.Database.SqlServer.Data;

using App.Domain.AppService;
using App.Domain.AppService.Admins.Commands;
using App.Domain.AppService.Admins.Queries;
using App.Domain.AppService.Customers.Commands;
using App.Domain.AppService.Customers.Queries;
using App.Domain.AppService.Sellers;
using App.Domain.AppService.Sellers.Commands;
using App.Domain.AppService.Sellers.Queries;
using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.Configs;
using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using App.Infrastructures.Data.Repositories;
using MarketPlace.Database;
using MarketPlace.ViewComponents;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ??
                                   throw new InvalidOperationException(
                                       "Connection string 'ApplicationDbContextConnection' not found.");

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
            builder.Services
                .AddScoped<IConfirmSellersProductServiceAppService, ConfirmSellersProductServiceAppService>();
            builder.Services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            builder.Services.AddScoped<IStoreCommentRepository, StoreCommentRepository>();
            builder.Services
                .AddScoped<IConfirmCustomersCommentServiceAppService, ConfirmCustomersCommentServiceAppService>();
            builder.Services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
            builder.Services.AddScoped<IAddNewStoreService, AddNewStoreService>();
            builder.Services.AddScoped<IGetAllStoresBySellerId, GetAllStoresBySellerId>();
            builder.Services.AddScoped<IAddNewStoreAddressService, AddNewStoreAddressService>();
            builder.Services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
            builder.Services.AddScoped<IAddNewProductService, AddNewProductService>();
            builder.Services.AddScoped<IAddProductPhotoService, AddProductPhotoService>();
            builder.Services.AddScoped<IGetStoreProductsService, GetStoreProductsService>();
            builder.Services.AddScoped<ICreateAuctionService, CreateAuctionService>();
            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            builder.Services.AddScoped<IGetStoreAuctionsService, GetStoreAuctionsService>();
            builder.Services.AddScoped<IAuctionService, AuctionService>();
            builder.Services.AddScoped<IGetInAuctionProductsService, GetInAuctionProductsService>();
            builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
            builder.Services.AddScoped<IBidRepository, BidRepository>();
            builder.Services
                .AddScoped<ICalculateTotalSalePricesForSellerService, CalculateTotalSalePricesForSellerService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IMedalRepository, MedalRepository>();
            builder.Services.AddScoped<ISetMedalForSellerService, SetMedalForSellerService>();
            builder.Services.AddScoped<IUpdateProductPriceInAuctionService, UpdateProductPriceInAuctionService>();
            builder.Services.AddScoped<IGetAuctionWithBidsService, GetAuctionWithBidsService>();
            builder.Services.AddScoped<IHomeCategoriesService, HomeCategoriesService>();
            builder.Services.AddScoped<IGetProductsByCategoriesService, GetProductsByCategoriesService>();
            builder.Services.AddScoped<IStoreProductsService, StoreProductsService>();
            builder.Services.AddScoped<IStoreServiceAppService, StoreServiceAppService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IBidService, BidService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IGetSellerIdByStoreIdService, GetSellerIdByStoreIdService>();
            builder.Services.AddScoped<ICalculateCommissionAmountService, CalculateCommissionAmountService>();
            builder.Services.AddScoped<ICommissionService, CommissionService>();
            builder.Services.AddScoped<ILeaveCommentForProductService, LeaveCommentForProductService>();
            builder.Services.AddScoped<IGetOrdersByUserIdService, GetOrdersByUserIdService>();
            builder.Services.AddScoped<IProductCommentService, ProductCommentService>();
            builder.Services.AddScoped<IGetCartOrderService, GetCartOrderService>();
            builder.Services.AddScoped<ICreateOrderService, CreateOrderService>();
            builder.Services.AddScoped<IHasOrderService, HasOrderService>();
            builder.Services.AddScoped<IGetOrderByIdService, GetOrderByIdService>();
            builder.Services.AddScoped<ICreateOrderItemService, CreateOrderItemService>();
            builder.Services.AddScoped<IUpdateOrderTotalPriceService, UpdateOrderTotalPriceService>();
            builder.Services.AddScoped<IRemoveCartOrderItemService, RemoveCartOrderItemService>();
            builder.Services.AddScoped<ICountOrderItemsService, CountOrderItemsService>();
            builder.Services.AddScoped<IRemoveOrderService, RemoveOrderService>();

            //Register the ViewComponents
            builder.Services.AddTransient<RandomProductsViewComponent>();
            builder.Services.AddTransient<ProductCommentsViewComponent>();
            builder.Services.AddTransient<AddCommentFormViewComponent>();

            builder.Services.AddControllersWithViews();

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json");

            var appConfigs = builder.Configuration.Get<AppConfigs>();
            builder.Services.AddSingleton(appConfigs);

            builder.Services.AddRazorPages();

            builder.Services.Configure<IdentityOptions>(options => { options.Password.RequireUppercase = false; });

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

            app.MapAreaControllerRoute(
                name: "areas",
                areaName: "Seller",
                pattern: "Seller/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}