using App.Domain.Core.DtoModels.ProductPhotos;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAddNewProductService
    {
        Task<ProductOutputDto> AddNewProduct(AddProductInputDto product, AddProductPhotoInputDto photo, CancellationToken cancellationToken);
    }
}
