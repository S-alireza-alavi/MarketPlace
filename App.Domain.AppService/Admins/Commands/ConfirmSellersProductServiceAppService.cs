using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DataAccess;

namespace App.Domain.AppService.Admins.Commands
{
    public class ConfirmSellersProductServiceAppService : IConfirmSellersProductServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public ConfirmSellersProductServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> ConfirmSellersProductAsync(int productId, CancellationToken cancellationToken)
        {
            bool isDone;

            var product = await _productRepository.GetProductBy(productId, cancellationToken);

            if (product != null)
            {
                product.IsActive = true;

                isDone = true;
            }
            else
            {
                isDone = false;
            }

            return isDone;
        }
    }
}
