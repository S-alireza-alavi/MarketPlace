using App.Domain.Core.DtoModels.ProductTags;

namespace App.Domain.Core.DataAccess
{
    public interface IProductTagRepository
    {
        Task<List<ProductTagOutputDto>> GetAllProductTags(CancellationToken cancellationToken);
        Task<ProductTagOutputDto>? GetProductTagBy(int id, CancellationToken cancellationToken);
        Task CreateProductTag(AddProductTagInputDto productTag, CancellationToken cancellationToken);
        Task UpdateProductTag(EditProductTagInputDto productTag, CancellationToken cancellationToken);
        Task DeleteProductTag(int id, CancellationToken cancellationToken);
    }
}
