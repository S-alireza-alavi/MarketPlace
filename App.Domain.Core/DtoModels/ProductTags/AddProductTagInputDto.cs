using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.ProductTags
{
    public class AddProductTagInputDto
    {
        public int ProductId { get; set; }

        public int TagId { get; set; }
    }
}
