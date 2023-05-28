namespace App.Domain.Core.DtoModels.Models;

public class EditModelInputDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int? ParentModelId { get; set; }

    public int BrandId { get; set; }
}