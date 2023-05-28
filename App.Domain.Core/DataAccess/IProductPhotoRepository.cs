using App.Domain.Core.DtoModels.ProductPhotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IProductPhotoRepository
    {
        Task<List<ProductPhotoOutputDto>> GetAllProductPhotos(CancellationToken cancellationToken);
        Task<ProductPhotoOutputDto>? GetProductPhotoBy(int id, CancellationToken cancellationToken);
        Task CreateProductPhoto(AddProductPhotoInputDto productPhoto, CancellationToken cancellationToken);
        Task UpdateProductPhoto(EditProductPhotoInputDto productPhoto, CancellationToken cancellationToken);
        Task DeleteProductPhoto(int id, CancellationToken cancellationToken);
    }
}
