using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Commisions
{
    public class AddCommissionInputDto
    {
        public int OrderId { get; set; }

        public int CommissionAmount { get; set; }
    }
}
