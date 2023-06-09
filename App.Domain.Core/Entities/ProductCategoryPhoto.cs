using MarketPlace.Entities;

namespace App.Domain.Core.Entities
{
    public class ProductCategoryPhoto
    {
        public int Id { get; set; }

        public string FileName { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int ProductCategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ProductCategory ProductCategory { get; set; } = null!;
    }
}
