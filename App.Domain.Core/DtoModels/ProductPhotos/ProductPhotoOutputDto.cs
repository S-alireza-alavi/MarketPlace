//using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class ProductPhotoOutputDto
    {
        public int Id { get; set; }

        public string FileName { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
