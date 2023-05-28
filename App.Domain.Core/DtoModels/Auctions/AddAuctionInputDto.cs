using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Auctions
{
    public class AddAuctionInputDto
    {
        public int StoreId { get; set; }

        public int SellerId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MinimumPrice { get; set; }

        public bool IsRunning { get; set; }

        public int ProductId { get; set; }
    }
}
