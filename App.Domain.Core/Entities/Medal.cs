using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Medal
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public ApplicationUser Seller { get; set; } = null!;
    }
}
