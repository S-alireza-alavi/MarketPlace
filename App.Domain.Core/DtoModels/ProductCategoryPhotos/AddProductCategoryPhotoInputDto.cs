using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.DtoModels.ProductCategoryPhotos
{
    public class AddProductCategoryPhotoInputDto
    {
        public IFormFile ImageFile { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int ProductCategoryId { get; set; }
    }
}
