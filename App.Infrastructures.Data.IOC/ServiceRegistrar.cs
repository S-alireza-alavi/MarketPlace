using App.Domain.AppService.Admins.Commands;
using App.Domain.AppService.Admins.Queries;
using App.Domain.AppService.Customers.Commands;
using App.Domain.AppService.Customers.Queries;
using App.Domain.AppService.Sellers.Commands;
using App.Domain.AppService.Sellers.Queries;
using App.Domain.AppService.Sellers;
using App.Domain.AppService;
using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Infrastructures.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.IOC
{
    public static class ServiceRegistrar
    {
        public static void RegisterServices()
        {
            //Services.AddScoped<IUserRepository, UserRepository>();
            //Services.AddScoped<IUsersAppService, UsersAppService>();
            //Services.AddScoped<IStoreRepository, StoreRepository>();
            //Services.AddScoped<IStoresServiceAppService, StoresServiceAppService>();
            //Services.AddScoped<IProductRepository, ProductRepository>();
            //Services.AddScoped<IProductsServiceAppService, ProductsServiceAppService>();
            //Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            //Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            //Services.AddScoped<IBrandRepository, BrandRepository>();
            //Services.AddScoped<IBrandsService, BrandsService>();
            //Services.AddScoped<IModelRepository, ModelRepository>();
            //Services.AddScoped<IModelService, ModelService>();
            //Services.AddScoped<IStoreAppService, StoreAppService>();
            //Services.AddScoped<ICommissionRepository, CommissionRepository>();
            //Services.AddScoped<ICommissionsServiceAppService, CommissionsServiceAppService>();
            //Services
            //    .AddScoped<IConfirmSellersProductServiceAppService, ConfirmSellersProductServiceAppService>();
            //builder.Services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            //builder.Services.AddScoped<IStoreCommentRepository, StoreCommentRepository>();
            //builder.Services
            //    .AddScoped<IConfirmCustomersCommentServiceAppService, ConfirmCustomersCommentServiceAppService>();
            //builder.Services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
            //builder.Services.AddScoped<IAddNewStoreService, AddNewStoreService>();
            //builder.Services.AddScoped<IGetAllStoresBySellerId, GetAllStoresBySellerId>();
            //builder.Services.AddScoped<IAddNewStoreAddressService, AddNewStoreAddressService>();
            //builder.Services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
            //builder.Services.AddScoped<IAddNewProductService, AddNewProductService>();
            //builder.Services.AddScoped<IAddProductPhotoService, AddProductPhotoService>();
            //builder.Services.AddScoped<IGetStoreProductsService, GetStoreProductsService>();
            //builder.Services.AddScoped<ICreateAuctionService, CreateAuctionService>();
            //builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            //builder.Services.AddScoped<IGetStoreAuctionsService, GetStoreAuctionsService>();
            //builder.Services.AddScoped<IAuctionService, AuctionService>();
            //builder.Services.AddScoped<IGetInAuctionProductsService, GetInAuctionProductsService>();
            //builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
            //builder.Services.AddScoped<IBidRepository, BidRepository>();
            //builder.Services
            //    .AddScoped<ICalculateTotalSalePricesForSellerService, CalculateTotalSalePricesForSellerService>();
            //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            //builder.Services.AddScoped<IMedalRepository, MedalRepository>();
            //builder.Services.AddScoped<ISetMedalForSellerService, SetMedalForSellerService>();
            //builder.Services.AddScoped<IUpdateProductPriceInAuctionService, UpdateProductPriceInAuctionService>();
            //builder.Services.AddScoped<IGetAuctionWithBidsService, GetAuctionWithBidsService>();
            //builder.Services.AddScoped<IHomeCategoriesService, HomeCategoriesService>();
            //builder.Services.AddScoped<IGetStoresByCategoriesService, GetStoresByCategoriesService>();
            //builder.Services.AddScoped<IStoreProductsService, StoreProductsService>();
            //builder.Services.AddScoped<IStoreServiceAppService, StoreServiceAppService>();
            //builder.Services.AddScoped<IProductService, ProductService>();
            //builder.Services.AddScoped<IBidService, BidService>();
            //builder.Services.AddScoped<IOrderService, OrderService>();
            //builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            //builder.Services.AddScoped<IGetSellerIdByStoreIdService, GetSellerIdByStoreIdService>();
            //builder.Services.AddScoped<ICalculateCommissionAmountService, CalculateCommissionAmountService>();
            //builder.Services.AddScoped<ICommissionService, CommissionService>();
            //builder.Services.AddScoped<ILeaveCommentForProductService, LeaveCommentForProductService>();
            //builder.Services.AddScoped<IGetOrdersByUserIdService, GetOrdersByUserIdService>();
            //builder.Services.AddScoped<IProductCommentService, ProductCommentService>();
        }
    }
}
