using App.Domain.Core.DtoModels.ProductPhotos;
using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAddNewProductService
    {
        Task<int> AddNewProduct(AddProductInputDto product, CancellationToken cancellationToken);
    }
}
