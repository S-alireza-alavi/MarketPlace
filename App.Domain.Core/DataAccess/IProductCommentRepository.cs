using App.Domain.Core.DtoModels.ProductComments;

namespace App.Domain.Core.DataAccess
{
    public interface IProductCommentRepository
    {
        Task<List<ProductCommentOutputDto>> GetAllProductComments(CancellationToken cancellationToken);
        Task<List<ProductCommentOutputDto>> GetConfirmedCommentsForProduct(int productId, CancellationToken cancellationToken);
        Task<ProductCommentOutputDto> GetProductCommentBy(int id, CancellationToken cancellationToken);
        Task<List<ProductCommentOutputDto>> GetAllUnConfirmedProductComments(CancellationToken cancellationToken);
        Task CreateProductComment(AddProductCommentInputDto productComment, CancellationToken cancellationToken);
        Task UpdateProductComment(EditProductCommentInputDto productComment, CancellationToken cancellationToken);
        Task DeleteProductComment(int id, CancellationToken cancellationToken);
    }
}
