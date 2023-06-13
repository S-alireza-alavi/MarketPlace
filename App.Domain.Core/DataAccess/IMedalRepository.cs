using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IMedalRepository
    {
        Task SetMedalForSeller(int sellerId, CancellationToken cancellationToken);
    }
}
