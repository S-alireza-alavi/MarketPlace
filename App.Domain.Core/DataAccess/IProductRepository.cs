﻿using App.Domain.Core.DtoModels.Products;

namespace App.Domain.Core.DataAccess
{
    public interface IProductRepository
    {
        Task<List<ProductOutputDto>> GetAllProducts(string? search, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllInActiveProducts(CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllInAuctionProducts(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetProductBy(int id, CancellationToken cancellationToken);
        Task<ProductOutputDto> GetProductDetails(int id, CancellationToken cancellationToken);
        Task<int> CreateProduct(AddProductInputDto inputDto, CancellationToken cancellationToken);
        Task UpdateProduct(EditProductInputDto product, CancellationToken cancellationToken);
        Task DeleteProduct(int id, CancellationToken cancellationToken);
        Task<int> ProductsCount(CancellationToken cancellationToken);
    }
}
