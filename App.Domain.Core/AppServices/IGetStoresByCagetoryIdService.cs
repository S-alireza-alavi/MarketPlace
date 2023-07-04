using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IGetStoresByCagetoryIdService
    {
        Task<List<StoreOutputDto>> GetStoresByCagetoryId(int categoryId, CancellationToken cancellationToken);
    }
}
