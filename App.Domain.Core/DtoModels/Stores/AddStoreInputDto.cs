namespace App.Domain.Core.DtoModels.Stores
{
    public class AddStoreInputDto
    {
        public string Name { get; set; } = null!;

        public int SellerId { get; set; }

        public string Description { get; set; } = null!;

        public int AddressId { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
