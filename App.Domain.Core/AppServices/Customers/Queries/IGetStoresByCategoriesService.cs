using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Customers.Queries
{
    public interface IGetStoresByCategoriesService
    {
        Task<List<StoreOutputDto>> GetStoresByCategories(int categoryId, CancellationToken cancellationToken);
    }
}
