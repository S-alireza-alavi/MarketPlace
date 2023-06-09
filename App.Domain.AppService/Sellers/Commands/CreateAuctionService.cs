using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class CreateAuctionService : ICreateAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;

        public CreateAuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<int> CreateAuctionAsync(AddAuctionInputDto inputDto, CancellationToken cancellationToken)
        {
            var result = await _auctionRepository.CreateAuction(inputDto, cancellationToken);
            return result;
        }
    }
}
