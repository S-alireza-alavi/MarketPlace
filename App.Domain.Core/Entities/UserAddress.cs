using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullAddress { get; set; } = null!;
        public bool? isDeleted { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
