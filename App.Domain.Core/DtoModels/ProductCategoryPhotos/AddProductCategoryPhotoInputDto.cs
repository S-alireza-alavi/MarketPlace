using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.DtoModels.ProductCategoryPhotos
{
    public class AddProductCategoryPhotoInputDto
    {
        public IFormFile ImageFile { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int ProductCategoryId { get; set; }
    }
}
