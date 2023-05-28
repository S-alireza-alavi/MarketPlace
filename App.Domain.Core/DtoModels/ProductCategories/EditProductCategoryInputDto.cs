namespace App.Domain.Core.DtoModels.ProductCategories
{
    public class EditProductCategoryInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }
    }
}
