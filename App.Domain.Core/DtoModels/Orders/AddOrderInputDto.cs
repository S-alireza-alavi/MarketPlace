using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Orders
{
    public class AddOrderInputDto
    {
        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int TotalPrice { get; set; }

        public bool IsPurchased { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
