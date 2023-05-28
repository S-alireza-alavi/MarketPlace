using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IStoresServiceAppService
    {
        Task<int> GetStoresCount(CancellationToken cancellationToken);
    }
}
