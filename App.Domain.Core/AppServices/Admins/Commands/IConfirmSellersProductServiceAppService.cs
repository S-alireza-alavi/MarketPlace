using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IConfirmSellersProductServiceAppService
    {
        Task<List<ProductOutputDto>> GetAllInActiveProducts(CancellationToken cancellationToken);
        Task<bool> ConfirmSellersProductAsync(int productId, CancellationToken cancellationToken);
    }
}
