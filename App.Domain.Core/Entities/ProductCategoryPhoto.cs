namespace App.Domain.Core.Entities;

public partial class ProductCategoryPhoto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ProductCategory ProductCategory { get; set; } = null!;
}
