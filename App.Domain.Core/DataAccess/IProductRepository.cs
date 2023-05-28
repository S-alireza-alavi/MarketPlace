using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IProductRepository
    {
        Task<List<ProductOutputDto>> GetAllProducts(CancellationToken cancellationToken);
        Task<ProductOutputDto>? GetProductBy(int id, CancellationToken cancellationToken);
        Task CreateProduct(AddProductInputDto product, CancellationToken cancellationToken);
        Task UpdateProduct(EditProductInputDto product, CancellationToken cancellationToken);
        Task DeleteProduct(int id, CancellationToken cancellationToken);
        Task<int> ProductsCount(CancellationToken cancellationToken);
    }
}
