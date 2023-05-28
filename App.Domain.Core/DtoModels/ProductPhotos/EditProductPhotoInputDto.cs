namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class EditProductPhotoInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
