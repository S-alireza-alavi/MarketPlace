using App.Domain.Core.DtoModels.ProductComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IProductCommentRepository
    {
        Task<List<ProductCommentOutputDto>> GetAllProductComments(CancellationToken cancellationToken);
        Task<ProductCommentOutputDto>? GetProductCommentBy(int id, CancellationToken cancellationToken);
        Task CreateProductComment(AddProductCommentInputDto productComment, CancellationToken cancellationToken);
        Task UpdateProductComment(EditProductCommentInputDto productComment, CancellationToken cancellationToken);
        Task DeleteProductComment(int id, CancellationToken cancellationToken);
    }
}
