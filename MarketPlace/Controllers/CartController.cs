using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.OrderItems;
using App.Domain.Core.DtoModels.Orders;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductService _productService;
        private readonly ICreateOrderService _createOrderService;
        private readonly IHasOrderService _hasOrderService;
        private readonly IGetCartOrderService _getCartOrderService;
        private readonly IGetOrderByIdService _getOrderByIdService;
        private readonly ICreateOrderItemService _createOrderItemService;
        private readonly IUpdateOrderTotalPriceService _updateOrderTotalPriceService;

        public CartController(UserManager<ApplicationUser> userManager, IProductService productService, ICreateOrderService createOrderService, IHasOrderService hasOrderService, IGetCartOrderService getCartOrderService, IGetOrderByIdService getOrderByIdService, ICreateOrderItemService createOrderItemService, IUpdateOrderTotalPriceService updateOrderTotalPriceService)
        {
            _userManager = userManager;
            _productService = productService;
            _createOrderService = createOrderService;
            _hasOrderService = hasOrderService;
            _getCartOrderService = getCartOrderService;
            _getOrderByIdService = getOrderByIdService;
            _createOrderItemService = createOrderItemService;
            _updateOrderTotalPriceService = updateOrderTotalPriceService;
        }

        public async Task<IActionResult> Cart(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);

            bool hasOrder = await _hasOrderService.HasOrder(user.Id, cancellationToken);

            if (hasOrder)
            {
                var order = await _getCartOrderService.GetCartOrder(user.Id, cancellationToken);
                return View(order);
            }
            else
            {
                return RedirectToAction("EmptyCart", "Cart");
            }
        }

        public async Task<IActionResult> AddToCart(int productId, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await _productService.GetProductBy(productId, cancellationToken);

            bool hasOrder = await _hasOrderService.HasOrder(user.Id, cancellationToken);

            if (!hasOrder)
            {
                var inputDto = new AddOrderInputDto
                {
                    SellerId = product.Store.SellerId,
                    CustomerId = user.Id,
                    TotalPrice = 0,
                    IsPurchased = false
                };

                var orderId = await _createOrderService.CreateOrder(inputDto, cancellationToken);

                var orderItem = new AddOrderItemInputDto
                {
                    OrderId = orderId,
                    ProductId = productId
                };

                await _createOrderItemService.CreateOrderItem(orderItem, cancellationToken);

                await _updateOrderTotalPriceService.UpdateOrderTotalPrice(orderId, cancellationToken);

                var order = await _getOrderByIdService.GetOrderById(orderId, cancellationToken);

                return RedirectToAction("Cart", "Cart", order);
            }
            else
            {
                var order = await _getCartOrderService.GetCartOrder(user.Id, cancellationToken);

                var orderItem = new AddOrderItemInputDto
                {
                    OrderId = order.Id,
                    ProductId = productId
                };

                await _createOrderItemService.CreateOrderItem(orderItem, cancellationToken);

                await _updateOrderTotalPriceService.UpdateOrderTotalPrice(order.Id, cancellationToken);

                return RedirectToAction("Cart", "Cart");
            }
        }

        public IActionResult EmptyCart()
        {
            return View();
        }
    }
}
