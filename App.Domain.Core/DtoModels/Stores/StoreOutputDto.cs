using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.Stores
{
    public class StoreOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SellerId { get; set; }

        public string Description { get; set; } = null!;

        public int AddressId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public StoreAddress Address { get; set; } = null!;
    }
}
