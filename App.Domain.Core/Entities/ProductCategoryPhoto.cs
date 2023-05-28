using MarketPlace.Entities;

namespace App.Domain.Core.Entities
{
    public class ProductCategoryPhoto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ProductCategory ProductCategory { get; set; } = null!;
    }
}
