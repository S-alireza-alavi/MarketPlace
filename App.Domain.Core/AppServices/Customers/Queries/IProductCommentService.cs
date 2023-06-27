using App.Domain.Core.DtoModels.ProductComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IProductCommentService
    {
        Task<List<ProductCommentOutputDto>> GetConfirmedCommentsForProduct(int productId, CancellationToken cancellationToken);
    }
}
