using MarketPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.StoreAddresses
{
    public class StoreAddressOutputDto
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string FullAddress { get; set; } = null!;

        public bool? IsDeleted { get; set; }

        public virtual Store Store { get; set; } = null!;
    }
}
