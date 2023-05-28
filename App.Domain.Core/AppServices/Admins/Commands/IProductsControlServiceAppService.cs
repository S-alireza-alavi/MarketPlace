using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IProductsControlServiceAppService
    {
        Task<ProductOutputDto> GetProduct(int productId, CancellationToken cancellationToken);
        Task<ProductOutputDto> EditProduct(EditProductInputDto product, CancellationToken cancellationToken);
        Task DeleteProduct(int productId, CancellationToken cancellationToken);
    }
}
