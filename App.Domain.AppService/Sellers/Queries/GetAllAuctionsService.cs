//using App.Domain.Core.AppServices.Sellers.Queries;
//using App.Domain.Core.DataAccess;
//using App.Domain.Core.DtoModels.Auctions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Domain.AppService.Sellers.Queries
//{
//    public class GetAllRunningAuctionsService : IGetAllRunningAuctionsService
//    {
//        private readonly IAuctionRepository _auctionRepository;

//        public GetAllRunningAuctionsService(IAuctionRepository auctionRepository)
//        {
//            _auctionRepository = auctionRepository;
//        }

//        public Task<List<AuctionOutputDto>> GetAllRunningAuctions(CancellationToken cancellationToken)
//        {
//            var auctions = _auctionRepository.GetAllRunningAuctions(cancellationToken);
//            return auctions;
//        }
//    }
//}
