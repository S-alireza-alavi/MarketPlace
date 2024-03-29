﻿using MarketPlace.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.DtoModels.Products
{
    public class ProductOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

        public int StoreId { get; set; }

        public decimal? Weight { get; set; }

        public string? Description { get; set; }

        public int? ModelId { get; set; }

        public int Price { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual Brand? Brand { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;

        public virtual Store Store { get; set; } = null!;

        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
    }
}
