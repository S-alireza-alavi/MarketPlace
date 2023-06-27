using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IGetSellerIdByStoreIdService
    {
        Task<int> GetSellerIdByStoreId(int storeId, CancellationToken cancellationToken);
    }
}
