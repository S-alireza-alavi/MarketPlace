using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IProductDetailService
    {
        Task<ProductOutputDto> GetProductDetail(int productId, CancellationToken cancellationToken);
    }
}
