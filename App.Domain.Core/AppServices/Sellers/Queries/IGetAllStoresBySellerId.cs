using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Queries
{
    public interface IGetAllStoresBySellerId
    {
        Task<List<StoreOutputDto>> GetAllStoresBySellerId(int sellerId, CancellationToken cancellationToken);
    }
}
