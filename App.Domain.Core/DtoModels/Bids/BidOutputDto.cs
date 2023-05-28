using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Bids
{
    public class BidOutputDto
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public int BuyerId { get; set; }

        public int BidAmount { get; set; }

        public DateTime BidTime { get; set; }
    }
}
