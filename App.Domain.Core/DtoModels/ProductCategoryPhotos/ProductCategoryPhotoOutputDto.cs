namespace App.Domain.Core.DtoModels.ProductCategoryPhotos
{
    public class ProductCategoryPhotoOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ProductCategoryId { get; set; }
    }
}
