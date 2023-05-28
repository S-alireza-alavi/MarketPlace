using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.DataAccess;

namespace App.Domain.AppService.Admins.Commands
{
    public class RejectSellersProductServiceAppService : IRejectSellersProductServiceAppService
    {
        private readonly IProductRepository _productRepository;

        public RejectSellersProductServiceAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> RejectSellersProductAsync(int productId, CancellationToken cancellationToken)
        {
            bool isDone;

            var product = await _productRepository.GetProductBy(productId, cancellationToken);

            if (product != null)
            {
                product.IsActive = false;

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
