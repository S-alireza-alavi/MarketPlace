using App.Domain.Core.DtoModels.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IStoreRepository
    {
        Task<List<StoreOutputDto>> GetAllStores(CancellationToken cancellationToken);
        Task<StoreOutputDto>? GetStoreBy(int id, CancellationToken cancellationToken);
        Task CreateStore(AddStoreInputDto store, CancellationToken cancellationToken);
        Task UpdateStore(EditStoreInputDto store, CancellationToken cancellationToken);
        Task DeleteStore(int id, CancellationToken cancellationToken);
        Task<int> StoresCount(CancellationToken cancellationToken);
    }
}
