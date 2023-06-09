using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Queries
{
    public interface IGetStoreProductsService
    {
        Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken);
    }
}
