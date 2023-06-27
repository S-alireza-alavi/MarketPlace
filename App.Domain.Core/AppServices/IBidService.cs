using App.Domain.Core.DtoModels.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IBidService
    {
        Task CreateBid(AddBidInputDto bid, CancellationToken cancellationToken);
    }
}
