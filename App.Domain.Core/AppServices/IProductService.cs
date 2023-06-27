using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IProductService
    {
        Task<ProductOutputDto> GetProductBy(int productId, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetRandomProducts(CancellationToken cancellationToken);
    }
}
