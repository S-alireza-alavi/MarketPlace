using App.Domain.Core.DtoModels.ProductPhotos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Sellers.Commands
{
    public interface IAddProductPhotoService
    {
        Task AddProductPhoto(AddProductPhotoInputDto productPhoto, CancellationToken cancellationToken);
    }
}
