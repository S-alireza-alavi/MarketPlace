using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;

namespace App.Domain.AppService.Admins.Queries
{
    public class StoresServiceAppService : IStoresServiceAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoresServiceAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<int> GetStoresCount(CancellationToken cancellationToken)
        {
            var count = _storeRepository.StoresCount(cancellationToken);

            return count;
        }
    }
}
