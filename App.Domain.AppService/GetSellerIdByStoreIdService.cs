using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class GetSellerIdByStoreIdService : IGetSellerIdByStoreIdService
    {
        private readonly IStoreRepository _storeRepository;

        public GetSellerIdByStoreIdService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<int> GetSellerIdByStoreId(int storeId, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetStoreBy(storeId);

            if (store != null)
            {
                return store.SellerId;
            }

            throw new ArgumentException($"غرفه‌ای با شناسه‌ی {storeId} وجود ندارد.");
        }
    }
}
