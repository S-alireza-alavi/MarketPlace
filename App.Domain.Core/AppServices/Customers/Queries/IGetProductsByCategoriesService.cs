using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IGetProductsByCategoriesService
    {
        Task<List<ProductOutputDto>> GetProductsByCategories(int categoryId, CancellationToken cancellationToken);
    }
}
