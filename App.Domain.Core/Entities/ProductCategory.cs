using App.Domain.Core.Entities;

namespace MarketPlace.Entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductCategoryPhoto> ProductCategoryPhotos { get; set; } = new List<ProductCategoryPhoto>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
