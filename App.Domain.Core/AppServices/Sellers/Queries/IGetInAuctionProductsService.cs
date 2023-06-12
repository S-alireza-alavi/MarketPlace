using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Queries
{
    public interface IGetInAuctionProductsService
    {
        Task<List<ProductOutputDto>> GetInAuctionProducts(CancellationToken cancellationToken);
    }
}
