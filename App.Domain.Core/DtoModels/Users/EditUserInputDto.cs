using MarketPlace.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.Users
{
    public class EditUserInputDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public List<string>? Roles { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
    }
}
