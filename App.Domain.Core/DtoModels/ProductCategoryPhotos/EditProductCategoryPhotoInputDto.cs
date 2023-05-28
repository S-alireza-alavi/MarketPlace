namespace App.Domain.Core.DtoModels.ProductCategoryPhotos
{
    public class EditProductCategoryPhotoInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ProductCategoryId { get; set; }
    }
}
