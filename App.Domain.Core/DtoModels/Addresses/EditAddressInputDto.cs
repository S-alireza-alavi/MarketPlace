namespace App.Domain.Core.DtoModels.Addresses;

public class EditAddressInputDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string FullAddress { get; set; } = null!;
}