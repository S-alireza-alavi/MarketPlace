﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Brands
{
    public class EditBrandInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
