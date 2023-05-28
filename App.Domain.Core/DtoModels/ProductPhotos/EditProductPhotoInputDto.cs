using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.ProductPhotos
{
    public class EditProductPhotoInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ProductId { get; set; }
    }
}
