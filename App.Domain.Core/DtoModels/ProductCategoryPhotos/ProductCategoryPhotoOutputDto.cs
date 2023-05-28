﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.ProductCategoryPhotos
{
    public class ProductCategoryPhotoOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ProductCategoryId { get; set; }
    }
}
