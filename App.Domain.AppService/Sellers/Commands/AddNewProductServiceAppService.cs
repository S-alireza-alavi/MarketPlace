﻿using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DtoModels.ProductPhotos;
using App.Domain.Core.DtoModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AddNewProductServiceAppService : IAddNewProductServiceAppService
    {
        public Task<ProductOutputDto> AddNewProduct(AddProductInputDto product, AddProductPhotoInputDto photo, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
