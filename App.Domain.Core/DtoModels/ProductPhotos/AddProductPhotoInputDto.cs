//using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class AddProductPhotoInputDto
    {
        public string FileName { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
