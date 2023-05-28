using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.Commisions
{
    public class CommissionOutputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CommissionAmount { get; set; }
    }
}
