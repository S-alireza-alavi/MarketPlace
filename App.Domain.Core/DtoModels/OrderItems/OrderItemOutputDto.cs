using MarketPlace.Entities;

namespace App.Domain.Core.DtoModels.OrderItems
{
    public class OrderItemOutputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
    }
}
