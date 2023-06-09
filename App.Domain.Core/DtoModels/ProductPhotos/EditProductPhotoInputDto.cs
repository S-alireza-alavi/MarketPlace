namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class EditProductPhotoInputDto
    {
        public int Id { get; set; }

        public string FileName { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
