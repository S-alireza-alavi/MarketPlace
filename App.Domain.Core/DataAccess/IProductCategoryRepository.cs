﻿using App.Domain.Core.DtoModels.ProductCategories;

namespace App.Domain.Core.DataAccess
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategoryOutputDto>> GetAllProductCategories(CancellationToken cancellationToken);
        Task<ProductCategoryOutputDto>? GetProductCategoryBy(int id, CancellationToken cancellationToken);
        Task CreateProductCategory(AddProductCategoryInputDto productCategory, CancellationToken cancellationToken);
        Task UpdateProductCategory(EditProductCategoryInputDto productCategory, CancellationToken cancellationToken);
        Task DeleteProductCategory(int id, CancellationToken cancellationToken);
    }
}