using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Commisions;
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
        private readonly IRemoveCartOrderItemService _removeCartOrderItemService;
        private readonly ICountOrderItemsService _countOrderItemsService;
        private readonly IRemoveOrderService _removeOrderService;
        private readonly ICalculateCommissionAmountService _calculateCommissionAmountService;
        private readonly ICommissionService _commissionService;
        private readonly IOrderService _orderService;

        public CartController(UserManager<ApplicationUser> userManager, IProductService productService, ICreateOrderService createOrderService, IHasOrderService hasOrderService, IGetCartOrderService getCartOrderService, IGetOrderByIdService getOrderByIdService, ICreateOrderItemService createOrderItemService, IUpdateOrderTotalPriceService updateOrderTotalPriceService, IRemoveCartOrderItemService removeCartOrderItemService, ICountOrderItemsService countOrderItemsService, IRemoveOrderService removeOrderService, ICalculateCommissionAmountService calculateCommissionAmountService, ICommissionService commissionService, IOrderService orderService)
        {
            _userManager = userManager;
            _productService = productService;
            _createOrderService = createOrderService;
            _hasOrderService = hasOrderService;
            _getCartOrderService = getCartOrderService;
            _getOrderByIdService = getOrderByIdService;
            _createOrderItemService = createOrderItemService;
            _updateOrderTotalPriceService = updateOrderTotalPriceService;
            _removeCartOrderItemService = removeCartOrderItemService;
            _countOrderItemsService = countOrderItemsService;
            _removeOrderService = removeOrderService;
            _calculateCommissionAmountService = calculateCommissionAmountService;
            _commissionService = commissionService;
            _orderService = orderService;
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

        [HttpPost]
        public async Task<IActionResult> RemoveOrderItem(int orderItemId, CancellationToken cancellationToken)
        {
            var orderId = await _removeCartOrderItemService.RemoveCartOrderItem(orderItemId, cancellationToken);
            await _updateOrderTotalPriceService.UpdateOrderTotalPrice(orderId, cancellationToken);

            var orderItemsCount = await _countOrderItemsService.CountOrderItems(orderId, cancellationToken);

            if (orderItemsCount == 0)
            {
                await _removeOrderService.RemoveOrder(orderId, cancellationToken);
            }

            return RedirectToAction("Cart", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int orderId, CancellationToken cancellationToken)
        {
            var commissionAmount = await _calculateCommissionAmountService.CalculateCommissionAmount(orderId, cancellationToken);

            var commission = new AddCommissionInputDto
            {
                Id = orderId,
                CommissionAmount = commissionAmount
            };

            await _commissionService.CreateCommission(commission, cancellationToken);

            await _orderService.SetOrderAsPurchased(orderId, cancellationToken);

            var order = await _getOrderByIdService.GetOrderById(orderId, cancellationToken);

            return View(order);
        }

        public IActionResult EmptyCart()
        {
            return View();
        }
    }
}
