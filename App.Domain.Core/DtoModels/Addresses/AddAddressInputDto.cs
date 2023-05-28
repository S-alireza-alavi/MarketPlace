namespace App.Domain.Core.DtoModels.Addresses
{
    public class AddAddressInputDto
    {
        public int CustomerId { get; set; }

        public string FullAddress { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
