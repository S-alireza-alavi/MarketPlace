using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.DtoModels.Stores;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IProductsServiceAppService
    {
        Task<List<ProductOutputDto>> GetAllProducts(string? search, CancellationToken cancellationToken);
        Task<ProductOutputDto> GetProductBy(int id, CancellationToken cancellationToken);
        Task UpdateProduct(EditProductInputDto store, CancellationToken cancellationToken);
        Task DeleteProduct(int id, CancellationToken cancellationToken);
        Task<int> GetProductsCount(CancellationToken cancellationToken);
    }
}
