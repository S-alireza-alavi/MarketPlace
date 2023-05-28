namespace App.Domain.Core.DtoModels.Tags;

public class AddTagInputDto
{
    public string Name { get; set; } = null!;

    public int TagCategoryId { get; set; }

    public bool HasValue { get; set; }
}