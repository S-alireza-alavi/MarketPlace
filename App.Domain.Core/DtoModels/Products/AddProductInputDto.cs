﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Products
{
    public class AddProductInputDto
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int StoreId { get; set; }

        public decimal? Weight { get; set; }

        public string? Description { get; set; }

        public int Count { get; set; }

        public int? ModelId { get; set; }

        public int Price { get; set; }

        public bool IsActive { get; set; }
    }
}
