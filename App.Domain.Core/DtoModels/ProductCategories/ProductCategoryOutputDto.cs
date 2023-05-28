using App.Domain.Core.Entities;
using MarketPlace.Entities;

namespace App.Domain.Core.DtoModels.ProductCategories
{
    public class ProductCategoryOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<ProductCategoryPhoto> ProductCategoryPhotos { get; set; } = new List<ProductCategoryPhoto>();
    }
}
