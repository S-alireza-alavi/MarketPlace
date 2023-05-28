//using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class AddProductPhotoInputDto
    {
        public string Name { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
