﻿using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.Entities;

namespace App.Domain.Core.AppServices.Customers.Queries;

public interface IStoreProductsServiceAppService
{
    Task<List<ProductOutputDto>> GetStoreProducts(int storeId, CancellationToken cancellationToken);

    List<Product> Test(int storeId);
}