using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductPhotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Sellers.Commands
{
    public class AddProductPhotoService : IAddProductPhotoService
    {
        private readonly IProductPhotoRepository _productPhotoRepository;

        public AddProductPhotoService(IProductPhotoRepository productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }

        public async Task AddProductPhoto(AddProductPhotoInputDto productPhoto, CancellationToken cancellationToken)
        {
            await _productPhotoRepository.CreateProductPhoto(productPhoto, cancellationToken);
        }
    }
}
